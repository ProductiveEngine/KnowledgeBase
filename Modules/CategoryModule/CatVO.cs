using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Base;
using DAL.Models;

namespace CategoryModule
{
    public class CatVO
    {
        public CatVO()
        {

        }

        public CatVO(String title)
        {
            this.Title = title;
        }

        public string Title { get; set; }


        public string Description { get; set; }



        public DateTime CreatedDate { get; set; }


        public DateTime? ModifiedDate { get; set; }


        public State State { get; set; }




        public int CategoryID { get; set; }


        public byte[] RowVersion { get; set; }        

    }
}
