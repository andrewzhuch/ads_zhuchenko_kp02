using System;

namespace lab7
{
    public class Hashtable
    {
        public Entry[] table;
        public double loadness;
        public int size;
        public Hashtable()
        {
            this.table = new Entry[16];
            this.loadness = 0.0;
            this.size = 0;
        }
        public int HashCode(Key key) 
        {
            int hashCode = 0;
            for(int i = 0; i < key.ToString().Length; i++)
            {
                hashCode = ((int)key.ToString()[i] * i) + hashCode;
            }
            return hashCode;
        }
        public int GetHash(Key key) 
        {
            return this.HashCode(key) % (table.Length - 1); 
        }
        public void InsertEntry(Entry entry)
        {
            if(this.loadness > 0.6)
            {
                Rehashing();
            }
            if(this.table[this.GetHash(entry.key)] == null || this.table[this.GetHash(entry.key)].value.address == "deleted")
            {
                this.table[this.GetHash(entry.key)] = entry;
                this.size++;
                this.loadness = (double)this.size / (double)this.table.Length;
            }
            else
            {
                for(int i = this.GetHash(entry.key) + 1; i < this.table.Length; i++)
                {
                    if(this.table[i] == null || this.table[i].value.address == "deleted")
                    {
                        this.table[i] = entry;
                        this.size++;
                        this.loadness = (double)this.size / (double)this.table.Length;
                        break;
                    }
                }
            }
        }
        public void Rehashing()
        {
            Entry[] newTable = new Entry[this.table.Length * 2];
            this.loadness = (double)this.size / (double)newTable.Length;
            for(int i = 0; i < this.table.Length; i++)
            {
                if(this.table[i] != null)
                {
                    newTable[this.HashCode(this.table[i].key) % (newTable.Length - 1)] = this.table[i];
                }
            }
            this.table = newTable;
        }
        public bool RemoveEntry(Key key)
        {
            if(this.table[this.GetHash(key)] != null && this.table[this.GetHash(key)].value.address != "deleted"
            && this.table[this.GetHash(key)].key.ToString() == key.ToString())
            {
                this.table[this.GetHash(key)].value.address = "deleted";
                this.size--;
                this.loadness = (double)size / (double)table.Length;
                return true;
            }
            else
            {
                for(int i = this.GetHash(key) + 1; i < this.table.Length; i++)
                {
                    if(this.table[i] != null && this.table[i].value.address != "deleted"
                    && this.table[i].key.ToString() == key.ToString())
                    {
                        this.table[i].value.address = "deleted";
                        this.size--;
                        this.loadness = (double)size / (double)table.Length;
                        return true;
                    }
                }
            }
            return false;
        }
        public Entry FindEntry(Key key)
        {  
            if(this.table[this.GetHash(key)] != null && this.table[this.GetHash(key)].value.address != "deleted" 
            && this.table[this.GetHash(key)].key.ToString() == key.ToString())
            {
                return this.table[this.GetHash(key)];
            }
            else
            {
                for(int i = this.GetHash(key) + 1; i < this.table.Length; i++)
                {
                    if(this.table[i] == null || this.table[i].value.address == "deleted")
                    {
                        return null;
                    }
                    else
                    {
                        if(this.table[i].key.ToString() == key.ToString())
                        {
                            return this.table[i];
                        }
                    }
                }
                return null;
            }
        }
        public void PrintTable()
        {
            for(int i = 0; i < this.table.Length; i++)
            {
                if(this.table[i] != null && this.table[i].value.address != "deleted")
                {
                    Console.WriteLine("Key: {0}, value: {1}", this.table[i].key, this.table[i].value);
                }
            }
        }
    }
}