using System;
using System.Collections.Generic;
namespace lab7
{
    public class DoctorsPatiensHashTable
    {
        public List<Entry>[] patiens;
        public double loadness;
        public int size;
        public DoctorsPatiensHashTable()
        {
            this.patiens = new List<Entry>[16];
            this.loadness = 0.0;
            this.size = 0;
        }
        public int HashCode(string familyDoctor) 
        {
            int hashCode = 0;
            for(int i = 0; i < familyDoctor.Length; i++)
            {
                hashCode = ((int)familyDoctor[i] * i) + hashCode;
            }
            return hashCode;
        }
        public int GetHash(string familyDoctor) 
        {
            return this.HashCode(familyDoctor) % (patiens.Length - 1); 
        }
        public void Addpatient(Entry entry)
        {
            if(loadness > 0.6)
            {
                this.Reheshing();
            }
            if(this.patiens[GetHash(entry.value.familyDoctor)] == null)
            {
                this.patiens[GetHash(entry.value.familyDoctor)] = new List<Entry>();
                this.patiens[GetHash(entry.value.familyDoctor)].Add(entry);
                size++;
                this.loadness = (double)this.size / (double)this.patiens.Length;
            }
            else if(this.patiens[GetHash(entry.value.familyDoctor)][0].value.familyDoctor.ToString() == entry.value.familyDoctor.ToString())
            {
                this.patiens[GetHash(entry.value.familyDoctor)].Add(entry);
            }
            else
            {
                for(int i = GetHash(entry.value.familyDoctor); i < this.patiens.Length; i++)
                {
                    if(this.patiens[i] == null)
                    {
                        this.patiens[i] = new List<Entry>();
                        this.patiens[i].Add(entry);
                        size++;
                        this.loadness = (double)this.size / (double)this.patiens.Length;
                    }
                    else if(this.patiens[i][0].value.familyDoctor.ToString() == entry.value.familyDoctor.ToString())
                    {
                        this.patiens[i].Add(entry);
                    }
                }
            }
        }
        public List<Entry> FindPatiens(string familyDoctor)
        {
            return this.patiens[GetHash(familyDoctor)];
        }
        public void Reheshing()
        {
            List<Entry>[] newPatiens = new List<Entry>[this.patiens.Length * 2];
            this.loadness = (double)this.size / (double)newPatiens.Length;
            for(int i = 0; i < this.patiens.Length; i++)
            {
                if(this.patiens[i] != null)
                {
                    newPatiens[this.HashCode(this.patiens[i][0].value.familyDoctor) % (newPatiens.Length - 1)] = this.patiens[i];
                }
            }
            this.patiens = newPatiens;
        }
        public void RemovePatient(Entry entry)
        {
            if(this.patiens[GetHash(entry.value.familyDoctor)][0].value.familyDoctor.ToString() == entry.value.familyDoctor.ToString())
            {
                for(int i = 0; i < this.patiens[GetHash(entry.value.familyDoctor)].Count; i++)
                {
                    if(this.patiens[GetHash(entry.value.familyDoctor)][i].ToString() == entry.ToString())
                    {
                        this.patiens[GetHash(entry.value.familyDoctor)].RemoveAt(i);
                        break;
                    }
                }   
            }
            else
            {
                for(int i = GetHash(entry.value.familyDoctor); i < this.patiens.Length; i++)
                {
                    if(this.patiens[i][0].value.familyDoctor.ToString() == entry.value.familyDoctor.ToString())
                    {
                        for(int j = 0; j < this.patiens[j].Count; j++)
                        {
                            if(this.patiens[i][j].ToString() == entry.ToString())
                            {
                                this.patiens[i].RemoveAt(j);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}