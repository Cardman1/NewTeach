//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeachBook.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeacherHasSubjects
    {
        public int idTD { get; set; }
        public Nullable<int> IdTeacher { get; set; }
        public Nullable<int> IdSubject { get; set; }
        public Nullable<int> Duration { get; set; }
    
        public virtual Subjects Subjects { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}