//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace isrpo_practice
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int ID_Student { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public string Othestvo { get; set; }
        public string Address { get; set; }
        public int id_contract { get; set; }
        public int id_pass { get; set; }
        public int id_room { get; set; }
    
        public virtual Badge Badge { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Room Room { get; set; }
    }
}
