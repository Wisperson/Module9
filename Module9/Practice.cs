using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module9
{
    public class Practice
    {
        public static void Start()
        {
            int SenderStorageSize = 578560;
            int FileSize = 780;
            int FileQuantity = SenderStorageSize / FileSize;
            List<HDD> HDDs = new List<HDD>();
            List<DVD> DVDs = new List<DVD>();
            List<Flash> Flashs = new List<Flash>();
            Copy(HDDs, SenderStorageSize, FileQuantity, FileSize);
            Copy(DVDs, SenderStorageSize, FileQuantity, FileSize);
            Copy(Flashs, SenderStorageSize, FileQuantity, FileSize);

        }
        private static void Copy<T>(List<T> List, int SenderStorageSize, int FileQuantity, int FileSize) where T : Storage, new()
        {
            int CopiedFileQuantity = 0;
            int i = 0;
            while (true)
            {
                if (CopiedFileQuantity >= FileQuantity)
                {
                    List[0].GetInfo();
                    Console.Write(
                        $"Time to copy: {SenderStorageSize / List[0].Speed} seconds\n" +
                        $"Storages to copy: {List.Count()}\n\n");
                    return;
                }
                if (List.Count() == 0)
                {
                    List.Add(new T());
                }
                while (List[i].GetFreeSpace() >= FileSize)
                {
                    List[i].GetFile(FileSize);
                    CopiedFileQuantity++;
                    if (List[i].GetFreeSpace() < FileSize)
                    {
                        List.Add(new T());
                        i++;
                    }
                    if (CopiedFileQuantity >= FileQuantity)
                    {
                        break;
                    }
                }
            }
        }
        public abstract class Storage
        {
            protected string Name;
            protected string Model;
            protected int Capacity;
            protected int MaxCapacity;
            public int Speed;
            public Storage() { }
            public abstract int GetMaxCapacity();
            public abstract int GetFreeSpace();
            public abstract void GetFile(int capacity);
            public abstract void GetInfo();
        }

        public class HDD: Storage
        {
            public HDD()
            {
                Name = "Seagate";
                Model = "Barracuda";
                Capacity = 0;
                MaxCapacity = 1048576;
                Speed = 100;
            }
            public override int GetMaxCapacity()
            {
                return MaxCapacity;
            }
            public override int GetFreeSpace()
            {
                return MaxCapacity - Capacity;
            }
            public override void GetInfo()
            {
                Console.Write(
                    $"Name: {Name}\n" +
                    $"Model: {Model}\n" +
                    $"Max Capacity: {MaxCapacity / 1024}gb\n" +
                    $"Speed: {Speed}mb/s\n\n");
            }
            public override void GetFile(int capacity)
            {
                Capacity += capacity;
            }
        }

        public class DVD : Storage
        {
            public DVD()
            {
                Name = "DVD";
                Model = "HDFilm+";
                Capacity = 0;
                MaxCapacity = 30720;
                Speed = 1;
            }
            public override int GetMaxCapacity()
            {
                return MaxCapacity;
            }
            public override int GetFreeSpace()
            {
                return MaxCapacity - Capacity;
            }
            public override void GetInfo()
            {
                Console.Write(
                    $"Name: {Name}\n" +
                    $"Model: {Model}\n" +
                    $"Max Capacity: {MaxCapacity / 1024}gb\n" +
                    $"Speed: {Speed}mb/s\n\n");
            }
            public override void GetFile(int capacity)
            {
                Capacity += capacity;
            }
        }

        public class Flash : Storage
        {
            public Flash()
            {
                Name = "Apacer";
                Model = "S350";
                Capacity = 0;
                MaxCapacity = 262144;
                Speed = 500;
            }
            public override int GetMaxCapacity()
            {
                return MaxCapacity;
            }
            public override int GetFreeSpace()
            {
                return MaxCapacity - Capacity;
            }
            public override void GetInfo()
            {
                Console.Write(
                    $"Name: {Name}\n" +
                    $"Model: {Model}\n" +
                    $"Max Capacity: {MaxCapacity / 1024}gb\n" +
                    $"Speed: {Speed}mb/s\n\n");
            }
            public override void GetFile(int capacity)
            {
                Capacity += capacity;
            }
        }
    }
}
