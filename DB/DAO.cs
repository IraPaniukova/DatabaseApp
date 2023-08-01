using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using Microsoft.EntityFrameworkCore;

namespace ProjectPaniukova.DB
{
    public class DAO
    {
        static public void addModel(TruckModel model)
        {
            using DadIraContext x = new DadIraContext();
            {
                x.TruckModels.Add(model);
                x.SaveChanges();
            }
        }

        static public List<TruckModel> getModels()
        {
            using DadIraContext x = new DadIraContext();
            {
                return x.TruckModels.ToList();
            }
        }
        static public List<TruckFeature> getFeatures()
        {
            using DadIraContext x = new DadIraContext();
            {
                return x.TruckFeatures.ToList();
            }
        }

       

        public static void addTruck(IndividualTruck i)
        {
            using (DadIraContext x = new DadIraContext())
            {
                
              //  foreach (TruckFeature f in x.TruckFeatures)
              //  { x.Entry(i.Features).State = EntityState.Unchanged; } 
                x.IndividualTrucks.Add(i);
                x.SaveChanges();
            }
        }
        public static TruckModel searchModelName(string name)
        {
            using (DadIraContext x = new DadIraContext())
            {
                TruckModel m = x.TruckModels.Where((y => y.Model == name)).FirstOrDefault();
                return m;
            }
        }
        public static TruckFeature searchFeature(int id)
        {
            using (DadIraContext x = new DadIraContext())
            {
                TruckFeature m = x.TruckFeatures.Where((y => y.FeatureId == id)).FirstOrDefault();
                return m;
            }
        }
        public static void addCustomer(TruckCustomer c)
        {
            using (DadIraContext x = new DadIraContext())
            {
                x.TruckCustomers.Add(c);
                x.SaveChanges();
            }
        }
        public static void addEmployee(TruckEmployee e)
        {
            using (DadIraContext x = new DadIraContext())
            {
                x.TruckEmployees.Add(e);
                x.SaveChanges();
            }
        }
        public static void addPerson(TruckPerson p)
        {
            using (DadIraContext x = new DadIraContext())
            {
                x.TruckPeople.Add(p);
                x.SaveChanges();

            }
        }
        static public List<TruckEmployee> getEmployees()
        {
            using DadIraContext x = new DadIraContext();
            {
                return x.TruckEmployees.ToList();
            }
        }
        public static void saveChangesEmployees(TruckEmployee n,TruckPerson p)
        {
            using (DadIraContext x = new DadIraContext())
            {
                x.Entry(n).State = EntityState.Modified;
                x.SaveChanges();
                x.Entry(p).State = EntityState.Modified;
                x.SaveChanges();
            }
        }
       
            public static void saveChangesCustomer(TruckCustomer n, TruckPerson p)
        {
            using (DadIraContext x = new DadIraContext())
            {
                x.Entry(n).State = EntityState.Modified;
                x.Entry(p).State = EntityState.Modified;
                x.SaveChanges();
            }
        }
        public static TruckEmployee searchEmployee(int id)
        {
            using (DadIraContext x = new DadIraContext())
            {
                TruckEmployee n = x.TruckEmployees.Where((y => y.EmployeeId == id)).FirstOrDefault();
                return n;
            }
        }
        public static TruckEmployee searchUsername(String u)
        {
            using (DadIraContext x = new DadIraContext())
            {
                TruckEmployee n = x.TruckEmployees.Where((y => y.Username == u)).FirstOrDefault();
                return n;
            }
        }

      


        public static TruckPerson searchPerson(int id)
        {
            using (DadIraContext x = new DadIraContext())
            {
                TruckPerson n = x.TruckPeople.Where((y => y.PersonId == id)).FirstOrDefault();
                return n;
            }
        }
        public static TruckCustomer searchCustomer(int id)
        {
            using (DadIraContext x = new DadIraContext())
            {
                TruckCustomer n = x.TruckCustomers.Where((y => y.CustomerId == id)).FirstOrDefault();
                return n;

            }
        }

        static public void addFeature(TruckFeature f)
        {
            using DadIraContext x = new DadIraContext();
            {
                x.TruckFeatures.Add(f);
                x.SaveChanges();
            }
        }

        public static List<EmployeeData> getEmplData()
        {
            using DadIraContext x = new DadIraContext();
            {
                return x.TruckEmployees.Include(c => c.Employee).Select(
                    em => new EmployeeData()
                    {
                        EmployeeId =em.EmployeeId,
                        EmployeeName = em.Employee.Name,
                        EmployeePhone = em.Employee.Telephone,
                        OfficeAddress=em.OfficeAddress,
                        PhoneExtentshion=em.PhoneExtensionNumber
                        
                    }).ToList();
                
            }
        }

    }
}
