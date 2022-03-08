using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Draft
    {
        [Key]
        public int DraftID { get; set; }
        public string DraftCreater { get; set; }
        public string DraftReceiver { get; set; }
        public string DraftContent { get; set; }
        public DateTime DraftDate { get; set; }
    }
}
