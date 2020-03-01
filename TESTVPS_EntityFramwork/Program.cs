using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TESTVPS_EntityFramwork
{
    public class VPS_Information
    {
        public int Id { get; set; }
        public string IP_Address { get; set; }
        public string User_Name { get; set; }
        public string Pass_Word { get; set; }
        public string Country { get; set; }
        public DateTime? Brought_Date { get; set; }
        public DateTime? Expiration_Date { get; set; }
        public string Put_Some_Notes { get; set; }
        public Status VPS_Status { get; set; }
    }
    public enum Status
    {
        Died = 0,
        Alive = 1
    }
    public class VPSContext : DbContext
    {
        public DbSet<VPS_Information> VPS_Informations { get; set; }

        public VPSContext()
            : base("name=DefaultConnection")
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Actions Action1 = new Actions();
            Action1.Show_Accout_Via_IP_Address("96");

            Console.WriteLine("Died_VPS");
            Action1.Show_Account_In_Status(0);
            Console.WriteLine("Alive_VPS");
            Action1.Show_Account_In_Status(1);
            Action1.Change_Pass_Words_All("newpasswords");
            Action1.Modidy_Data_Via_IP_Adress("100.100.100.100");
            Action1.Delete_Died_VPS_Adress();
            Console.ReadKey();
        }
    }
}
