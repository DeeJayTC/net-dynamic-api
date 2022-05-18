//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using TCDev.APIGenerator.Attributes;
//using TCDev.APIGenerator.Interfaces;

//namespace ApiGeneratorSampleApI.Model
//{

//    [Api("/students")]
//    public class Student: IObjectBase<int>
//    {
//        public int Id { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime DateOfBirth { get; set; }
    
//        public void BeforeDelete(Student student)
//        {
//            // Before Delete hook to make custom validations
//        }
    
//    }
    

//    [Api("/teachers")]
//    public class Teacher : IObjectBase<int>
//    {
//        public int Id { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime DateOfBirth { get; set; }

//        public void BeforeCreate(Teacher newTeacher)
//        {
//            // Before Create hook to make custom validations
//        }
//    }


//    [Api("/courses")]
//    public class Course : IObjectBase<int>
//    {
//        public int Id { get; set; }
//        public List<Student> Students { get; set; }
//        public Teacher Teacher { get; set; }
//        public List<DateTime> Schedule { get; set; }
//    }




//    [Api("/car"]
//    public class Car : IObjectBase<Guid>
//   {
//      [Key]
//      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//      [SwaggerIgnore]
//      public Guid Id { get; set; } = Guid.NewGuid();


//      [EmailAddress]
//      public string Name { get; set; }

//      public string Description { get; set; }

//      public string Color { get; set; }

//      public Make? Make { get; set; }

//      public Model? Model { get; set; }
//   }


//   [Api("/carMakes",
//       authorize: true,
//       requiredReadScopes: new string[] { "make.read" },
//       requiredWriteScopes: new string[] { "make.write" })]
//    public class Make : IObjectBase<Guid>
//   {
//      [Key]
//      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//      [SwaggerIgnore]
//      public Guid Id { get; set; } = Guid.NewGuid();
//      public string Name { get; set; }

//      public string Description { get; set; }


//      public Model? Model { get; set; }
//    }



//   [Api("/carModel",
//       authorize: true,
//       requiredReadScopes: new string[] { "model.read" },
//       requiredWriteScopes: new string[] { "model.write" })]
//    public class Model : IObjectBase<Guid>, I
//   {
//       [Key]
//       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//       [SwaggerIgnore]
//       public Guid Id { get; set; } = Guid.NewGuid();
//       public string Name { get; set; }

//       public string Description { get; set; }
//   }

//}
