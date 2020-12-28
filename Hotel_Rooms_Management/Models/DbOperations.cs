using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hotel_Rooms_Management.Models
{
    class DbOperations
    {
        private HotelModel db;

        public DbOperations()
        {
            db = new HotelModel();
        }

        public ObservableCollection<Room> GetAvailableRooms()
        {
            var r = db.Room.Select(c => c)
                .Where(c => c.Status == false).ToList();
            return new ObservableCollection<Room>(r);
        }

        public ObservableCollection<Customer> GetCustomers()
        {
            var r = db.Customer.Select(c => c).ToList();
            return new ObservableCollection<Customer>(r);
        }

        public ObservableCollection<Service> GetServices()
        {
            var r = db.Service.Select(c => c).ToList();
            return new ObservableCollection<Service>(r);
        }

        public int AddCustomer(Customer c)
        {
            db.Customer.Add(c);
            db.SaveChanges();
            return c.Customer_Id;
        }

        public int AddRoom(Room r)
        {
            db.Room.Add(r);
            db.SaveChanges();
            return r.Room_Id;
        }

        public int AddService(Service s)
        {
            db.Service.Add(s);
            db.SaveChanges();
            return s.Service_Id;
        }

        public int AddServiceString(ServiceString ss)
        {
            db.ServiceString.Add(ss);
            db.SaveChanges();
            return ss.ServiceString_Id;
        }

        public int AddOrder(Order o)
        {
            db.Order.Add(o);
            db.SaveChanges();
            return o.Order_Id;
        }

        public List<int> GetServiceIdByOrderId(int OrderId)
        {
            return db.ServiceString
                .Where(c => c.Order_FK == OrderId)
                .Select(c => c.Service_FK)
                .ToList();
        }
        public List<int> GetOrderIdByServiceId(int servId)
        {
            return db.ServiceString
                .Where(c => c.Service_FK == servId)
                .Select(c => c.Order_FK)
                .ToList();
        }

        public void UpdateService(Service serv)
        {
            Service s = db.Service.Where(c => c.Service_Id == serv.Service_Id).FirstOrDefault();
            if(s != null)
            {
                s.Name = serv.Name;
                s.Price = serv.Price;
                db.SaveChanges();
            }
        }

        public void UpdateRoom(Room rm)
        {
            Room r = db.Room.Where(c => c.Room_Id == rm.Room_Id).FirstOrDefault();
            if(r != null)
            {
                r.Name = rm.Name;
                r.Price = rm.Price;
                r.Beds = rm.Beds;
                r.Photo_Path = rm.Photo_Path;
                db.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer cs)
        {
            Customer c = db.Customer.Where(g => g.Customer_Id == cs.Customer_Id).FirstOrDefault();
            if(c != null)
            {
                c.Name = cs.Name;
                c.Phone = cs.Phone;
                c.Passport = cs.Passport;
                c.Sex = cs.Sex;
                db.SaveChanges();
            }
        }

        public string GetServiceStringByOrderId(int OrderId)
        {
            string s = "";
            var res = db.ServiceString
                .Where(i => i.Order_FK == OrderId)
                .Select(i => new { i.Service.Name, i.Price })
                .ToList();
            foreach (var item in res)
                s = $"{s} {item.Name} {item.Price}.";
            return s;
        }

        public List<Order> GetOrdersByPeriod(DateTime date_start)
        {
            return db.Order
                .Where(i => i.Date_start.Month == date_start.Month &&
                i.Date_start.Year == date_start.Year).ToList();
        }
    }
}
