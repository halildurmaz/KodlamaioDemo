using Entities.Concrete;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;

InstructorManager instructorManager = new InstructorManager(new InstructorDal());
CategoryManager categoryManager = new CategoryManager(new CategoryDal());
CourseManager courseManager = new CourseManager(new CourseDal());
void DataSeeds()
{
    Category category = new() { Id = 1, Name = "Mobil" };
    Category category1 = new() { Id = 2, Name = "Backend" };
    Category category2 = new() { Id = 3, Name = "Frontend" };
    Category category3 = new() { Id = 4, Name = "Game" };

    Instructor instructor = new() { Id = 1, IdentityNumber = 12345678910, FirstName = "Halil", LastName = "Durmaz" };
    Instructor instructor2 = new() { Id = 2, IdentityNumber = 12345678911, FirstName = "Enes", LastName = "Dursun" };
    Instructor instructor3 = new() { Id = 3, IdentityNumber = 12345678912, FirstName = "Hakan", LastName = "Durmaz" };

    //Course course = new Course()
    //{
    //    Id = 1,
    //    CategoryId = 1,
    //    InstructorId = 1,
    //    Name = "Swift Eğitimi",
    //    Description = "Profesyonel ve sürekli güncellenen eğitim içeriği ile temelden ileri seviyeye SwiftUI ile IOS mobil uygulama geliştirme."
    //};

    //Course course1 = new Course()
    //{
    //    Id = 2,
    //    CategoryId = 2,
    //    InstructorId = 2,
    //    Name = "C# Eğitimi",
    //    Description = "C# ile Başlangıç ve İleri Seviyede Windows Form ve Veritabanı Uygulamaları"
    //};

    //Course course2 = new Course()
    //{
    //    Id = 3,
    //    CategoryId = 3,
    //    InstructorId = 3,
    //    Name = "HTML Eğitimi",
    //    Description = "Profesyonel ve sürekli güncellenen eğitim içeriği ile temelden ileri seviyeye HTML öğreniyoruz."
    //};



    instructorManager.Add(instructor);
    instructorManager.Add(instructor2);
    instructorManager.Add(instructor3);


    categoryManager.Add(category);
    categoryManager.Add(category1);
    categoryManager.Add(category2);
    categoryManager.Add(category3);


    //courseManager.Add(course);
    //courseManager.Add(course1);
    //courseManager.Add(course2);
}

void CourseAdd()
{
    string courseName;
    int courseId, instructorId, categoryId;
    Console.WriteLine("------------------ Kurs Ekle ------------------");
    Console.Write("\nKurs Id: ");
    courseId = Convert.ToInt32(Console.ReadLine());
    Console.Write("\nKurs Adı: ");
    courseName = Console.ReadLine();

    var instructorList = instructorManager.GetAll();
    foreach (var instructor in instructorList)
    {
        Console.WriteLine("Id: " + instructor.Id +" " + instructor.FirstName + " " + instructor.LastName); 
    }
    Console.Write("\nEğitmen Id: ");
    instructorId = Convert.ToInt32(Console.ReadLine());
    Console.Write("\nKategori Id: ");
    categoryId = Convert.ToInt32(Console.ReadLine());

    Course course = new();
    course.Id = courseId;
    course.Name = courseName;

}
void CourseUpdate()
{

}

void CourseDelete()
{

}

void CourseGetAll()
{

}

void CourseGetById()
{

}
void CourseOperation()
{
    int choise;
    Console.WriteLine("------------------ Kurs İşlemleri ------------------");
    Console.WriteLine("\n1-Kurs Ekle");
    Console.WriteLine("2-Kurs Güncelle");
    Console.WriteLine("3-Kurs Sil");
    Console.WriteLine("4-Kursları Listele");
    Console.WriteLine("5-Kurs Arama(ID)");
    Console.Write("\nSeçiminiz: ");
    choise = Convert.ToInt32(Console.ReadLine());
    switch (choise)
    {
        case 1:
            CourseAdd();
            break;
        case 2:
            CourseUpdate();
            break;
        case 3:
            CourseDelete();
            break;
        case 4:
            CourseGetAll();
            break;
        case 5:
            CourseGetById();
            break;
        default:
            break;
    }
}


void CategoryOperation()
{

}
void MainPage()
{
    int choise;

    Console.WriteLine("------------------ Ana Menü ------------------");
    Console.WriteLine("\n1-Kurs İşlemleri");
    Console.WriteLine("2-Kategori İşlemleri");
    Console.WriteLine("3-Eğitmen İşlemleri");
    Console.Write("\nSeçiminiz: ");
    choise = Convert.ToInt32(Console.ReadLine());
    switch (choise)
    {
        case 1:
            CourseOperation();
            break;
        case 2:
            CategoryOperation();
            break;
        case 3:
            InstructorOperation();
            break;
        default:
            break;
    }
}


DataSeeds();
MainPage();


