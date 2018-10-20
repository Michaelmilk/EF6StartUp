using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFOperation.DbModels
{
    [Table("DbDataV2")]
    public class DbData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public DbData()
        { }

        public DbData(string name, string desc)
        {
            this.Name = name;
            this.Desc = desc;
        }
    }
}
