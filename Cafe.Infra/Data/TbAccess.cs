using System;
using System.Collections.Generic;

namespace Cafe.Infra.Data
{
    public partial class TbAccess
    {
        public int Id { get; set; }
        public string DsEmail { get; set; }
        public string DsPassword { get; set; }
        public bool StActive { get; set; }
        public string DsPerfil { get; set; }
        public string DsName { get; set; }
        public string DsLastName { get; set; }
        public DateTime? DtAccess { get; set; }
    }
}
