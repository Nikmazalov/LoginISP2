//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginISP2
{
    using System;
    using System.Collections.Generic;
    
    public partial class User2
    {
        public int IdUser2 { get; set; }
        public string Login2 { get; set; }
        public string Password2 { get; set; }
        public int IdRole2 { get; set; }
    
        public virtual Role2 Role2 { get; set; }
    }
}
