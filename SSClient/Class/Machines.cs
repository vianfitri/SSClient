using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;
using SSClient.Class;
using SSClient.Forms;
using Machines;

namespace SSClient.Class
{
    static class MachineModule
    {
        public static MachinesClass Machines = new MachinesClass();
    }

    public class MachinesClass : CollectionBase
    {
        public bool Dirty = false;
        private static Semaphore _pool;

        #region "Property"
        public Machine this[string Name]
        {
            get
            {
                //if (List.Count > 0)
                //{
                //    foreach (Machine m in from m1 in List as Machine[]
                //                          where m1.Name == Name
                //                          select m1)
                //    {
                //        return m;
                //    }
                //}
                foreach(Machine m in List)
                {
                    if (m.Name == Name)
                        return m;
                }
                return null;
            }
            set
            {
                MachineModule.Machines[Name] = value;
            }
        }

        public Machine this[int Index]
        {
            get
            {
                return (Machine)List[Index];
            }
        }
        #endregion

        #region "Method"
        public void Load(Semaphore pool)
        {
            _pool = pool;
            Import(GetFile());
        }

        public void Save()
        {
            if (!Dirty)
                return;

            Export(GetFile());
            Dirty = false;
        }

        public string GetFile()
        {
            string machineSettings = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ShipStab\\machines.bin";
            return machineSettings;
        }

        public void Import(string filename)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(MachinesClass));
                FileStream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                MachineModule.Machines = (MachinesClass)serializer.Deserialize(fStream);
                fStream.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Machines::Import " + ex.Message);
            }
        }

        public void Export(string filename)
        {
            var serializer = new XmlSerializer(typeof(MachinesClass));
            StreamWriter writer;

            try
            {
                writer = new StreamWriter(filename);
                serializer.Serialize(writer, MachineModule.Machines);
                writer.Close();
            }
            catch(UnauthorizedAccessException uaex)
            {
                if (MessageBox.Show(uaex.Message, "Changes have not been saved", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) == DialogResult.Retry)
                    Export(filename);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Changes have not been saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update(Machine machine)
        {
            Dirty = true;
        }

        public void Add(Machine machine)
        {
            List.Add(machine);

            machine.Pool = _pool;
            machine.Run();
            Dirty = true;
        }

        public void Remove(string name)
        {
            Machine machine = MachineModule.Machines[name];

            if (machine == null)
                return;
            machine.Cancel();

            List.Remove(machine);
            Dirty = true;
        }

        public void Close()
        {
            foreach(Machine machine in List)
            {
                machine.Cancel();
            }
        }
        #endregion
    }
}
