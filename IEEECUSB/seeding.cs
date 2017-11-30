using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IEEECUSB
{
    class seeding
    {
        public seeding()
        {
            Controller cont=new Controller();
            //create committee
            for (int i = 0; i < 10; i++)
            {
                string Name = "Committee" + i.ToString();
                cont.InsertCommittee(2019,Name);

            }
            //create requests
            for (int i = 0; i < 10; i++)
            {
                string Title = "Title" + i.ToString();
                cont.InsertRequest(Title,i,9-i);

            }
        }
    }
}
