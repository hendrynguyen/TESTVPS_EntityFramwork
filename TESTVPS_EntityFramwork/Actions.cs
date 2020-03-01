using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTVPS_EntityFramwork
{
    class Actions
    {
        public void Show_Information( VPS_Information vps)
        {
            Console.WriteLine("IP_Address: {0}, Username: {1}, Password: {2}, Country: {3}, Status: {4}", vps.IP_Address, vps.User_Name, vps.Pass_Word, vps.Country, vps.VPS_Status);
        }

        public void Show_Account_In_Status(int Account_Status)
        {
            var context = new VPSContext();
            var vps_list = context.VPS_Informations.Where(c => (int)c.VPS_Status == Account_Status);
            foreach (var vps in vps_list)
            {
                Show_Information(vps);
            }
        }
        public void Change_Pass_Words_All(string New_Passwords)
        {
            var context = new VPSContext();
            var vps_list = context.VPS_Informations.ToList();

            foreach(var vps in vps_list)
            {
                vps.Pass_Word = New_Passwords;
            }
            context.SaveChanges();
        }
        public void Show_Accout_Via_IP_Address(string IP_Address)
        {
            var context = new VPSContext();
            var vps_list = context.VPS_Informations.Where(c => c.IP_Address.Contains(IP_Address));
            foreach (var vps in vps_list)
            {
                Show_Information(vps);
            }
        }
        public void Modidy_Data_Via_IP_Adress(string IP_Address)
        {
            var context = new VPSContext();
            var vps_list = context.VPS_Informations.Where(c => c.IP_Address == IP_Address);
            
            if (vps_list.Count() == 0)
            {
                Console.WriteLine("There is no IP_Address Matched");
            }
            else
            {
                foreach (var vps in vps_list)
                {
                    vps.User_Name = "newname";
                }
                context.SaveChanges();
                Console.WriteLine("VPS Information after Motifying");
                foreach (var vps in vps_list)
                {
                    Show_Information(vps);
                }
            }
        }
        public void Delete_Died_VPS_Adress ()
        {
            var context = new VPSContext();
            var vps_list = context.VPS_Informations.Where(c => (int)c.VPS_Status == 0);
            foreach (var vps in vps_list)
            {
                context.VPS_Informations.Remove(vps);
            }
            context.SaveChanges();
        }
    }
}
