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

void RoutingHelper()
{
    Console.WriteLine("\n\nAna Menüye Yönlendiriliyor...");
    Thread.Sleep(3000);
    Console.Clear();
    MainPage();
}
void CourseAdd()
{
    string courseName, courseDescription;
    int courseId, instructorId, categoryId;
    Console.WriteLine("------------------ Kurs Ekle ------------------");
    Console.Write("\nKurs Id: ");
    courseId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Kurs Adı: ");
    courseName = Console.ReadLine();
    Console.Write("Kurs Açıklaması: ");
    courseDescription = Console.ReadLine();

    var instructorList = instructorManager.GetAll();
    Console.WriteLine("");
    foreach (var instructor in instructorList)
    {
        Console.WriteLine("Id: " + instructor.Id + " " + instructor.FirstName + " " + instructor.LastName);
    }
    Console.Write("\nEğitmen Id: ");
    instructorId = Convert.ToInt32(Console.ReadLine());

    var categoryList = categoryManager.GetAll();
    Console.WriteLine("");
    foreach (var category in categoryList)
    {
        Console.WriteLine("Id: " + category.Id + " " + category.Name);
    }
    Console.Write("\nKategori Id: ");
    categoryId = Convert.ToInt32(Console.ReadLine());

    Course course = new();
    course.Id = courseId;
    course.Name = courseName;
    course.CategoryId = categoryId;
    course.InstructorId = instructorId;
    course.Description = courseDescription;

    courseManager.Add(course);
    Console.WriteLine("\nKurs Ekleme Başarılı!");
    RoutingHelper();
}
void CourseUpdate()
{
    string courseName, courseDescription;
    int courseId, instructorId, categoryId;
    Console.WriteLine("------------------ Kurs Güncelleme ------------------");
    Console.Write("\nKurs Id: ");
    courseId = Convert.ToInt32(Console.ReadLine());
    Console.Write("\nKurs Adı: ");
    courseName = Console.ReadLine();
    Console.Write("Kurs Açıklaması: ");
    courseDescription = Console.ReadLine();

    var instructorList = instructorManager.GetAll();
    Console.WriteLine("");
    foreach (var instructor in instructorList)
    {
        Console.WriteLine("Id: " + instructor.Id + " " + instructor.FirstName + " " + instructor.LastName);
    }
    Console.Write("\nEğitmen Id: ");
    instructorId = Convert.ToInt32(Console.ReadLine());

    var categoryList = categoryManager.GetAll();
    Console.WriteLine("");
    foreach (var category in categoryList)
    {
        Console.WriteLine("Id: " + category.Id + " " + category.Name);
    }
    Console.Write("\nKategori Id: ");
    categoryId = Convert.ToInt32(Console.ReadLine());

    Course course = new();
    course.Id = courseId;
    course.Name = courseName;
    course.CategoryId = categoryId;
    course.InstructorId = instructorId;
    course.Description = courseDescription;

    courseManager.Update(course);
    Console.WriteLine("Kurs Güncelleme Başarılı!");
    RoutingHelper();

}

void CourseDelete()
{
    string courseName, courseDescription;
    int courseId, instructorId, categoryId;
    Console.WriteLine("------------------ Kurs Silme ------------------");
    var courseList = courseManager.GetAll();
    foreach (var item in courseList)
    {
        Console.WriteLine("Id: " + item.Id + "\nKurs: " + item.Name + "\nAçıklama: " + item.Description + "\nKategori Id: " + item.CategoryId + "\nEğitmen Id: " + item.InstructorId);
    }

    Console.Write("Kurs Id: ");
    courseId = Convert.ToInt32(Console.ReadLine());

    var course = courseManager.GetById(courseId);
    courseManager.Delete(course);
    Console.WriteLine("Kurs Silme İşlemi Başarılı!");
    RoutingHelper();
}

void CourseGetAll()
{
    Console.WriteLine("------------------ Kurs Listeleme ------------------");
    var courseList = courseManager.GetAll();
    foreach (var course in courseList)
    {
        Console.WriteLine("Id: " + course.Id + "\nKurs: " + course.Name + "\nAçıklama: " + course.Description + "\nKategori Id: " + course.CategoryId + "\nEğitmen Id: " + course.InstructorId + "\n");
    }
    Console.WriteLine("\n\nAna sayfaya dönmek için herhangi bir tuşa basınız...");
    Console.ReadLine();
    RoutingHelper();
}

void CourseGetById()
{
    int courseId;
    Console.WriteLine("------------------ Kurs Bulma ------------------");
    Console.WriteLine("Kurs Id: ");
    courseId = Convert.ToInt32(Console.ReadLine());
    var course = courseManager.GetById(courseId);
    Console.WriteLine("Id: " + course.Id + "\nKurs: " + course.Name + "\nAçıklama: " + course.Description + "\nKategori Id: " + course.CategoryId + "\nEğitmen Id: " + course.InstructorId);
    Console.WriteLine("\n\nAna sayfaya dönmek için herhangi bir tuşa basınız...");
    Console.ReadLine();
    RoutingHelper();
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


void InstructorOperation()
{
    int choise;
    Console.WriteLine("------------------ Eğitmen İşlemleri ------------------");
    Console.WriteLine("\n1-Eğitmen Ekle");
    Console.WriteLine("2-Eğitmen Güncelle");
    Console.WriteLine("3-Eğitmen Sil");
    Console.WriteLine("4-Eğitmenleri Listele");
    Console.WriteLine("5-Eğitmen Arama(ID)");
    Console.Write("\nSeçiminiz: ");
    choise = Convert.ToInt32(Console.ReadLine());
    switch (choise)
    {
        case 1:
            InstructorAdd();
            break;
        case 2:
            InstructorUpdate();
            break;
        case 3:
            InstructorDelete();
            break;
        case 4:
            InstructorGetAll();
            break;
        case 5:
            InstructorGetById();
            break;
        default:
            break;
    }
}

void InstructorAdd()
{
    string firstName, lastName; int id, identityNumber;
    Console.WriteLine("------------------ Eğitmen Ekle ------------------");

    Console.Write("Eğitmen Id: ");
    id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Eğitmen Tc: ");
    identityNumber = Convert.ToInt32(Console.ReadLine());
    Console.Write("Eğitmen Adı: ");
    firstName = Console.ReadLine();
    Console.Write("Eğitmen Soyadı: ");
    lastName = Console.ReadLine();

    Instructor instructor = new Instructor() { Id = id, IdentityNumber = identityNumber, FirstName = firstName, LastName = lastName };

    instructorManager.Add(instructor);
    Console.WriteLine("\nEğitmen başarıyla eklendi !");
    RoutingHelper();


}
void InstructorUpdate()
{
    string firstName, lastName; 
    int id, identityNumber;

    Console.WriteLine("------------------ Eğitmen Güncelle ------------------");
    Console.Write("Eğitmen Id: ");
    id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Eğitmen Tc: ");
    identityNumber = Convert.ToInt32(Console.ReadLine());
    Console.Write("Eğitmen Adı: ");
    firstName = Console.ReadLine();
    Console.Write("Eğitmen Soyadı: ");
    lastName = Console.ReadLine();

    Instructor instructor = new Instructor() { Id = id, IdentityNumber = identityNumber, FirstName = firstName, LastName = lastName };

    instructorManager.Update(instructor);
    Console.WriteLine("Eğitmen başarıyla güncellendi !");
    RoutingHelper();
}

void InstructorDelete()
{
    int id;

    Console.WriteLine("------------------ Eğitmen Sil ------------------");

    Console.Write("\nKategori Id: ");
    id = Convert.ToInt32(Console.ReadLine());

    var result = instructorManager.GetById(id);

    instructorManager.Delete(result);
    Console.WriteLine("Eğitmen başarıyla silindi !");
    RoutingHelper();
}

void InstructorGetAll()
{
    var result = instructorManager.GetAll();
    foreach (var item in result)
    {
        Console.WriteLine("Id: " + item.Id + "\nEğitmen Adı: " + item.FirstName+ " " + item.LastName + "\nEğitmen TC: " + item.IdentityNumber + "\n");
    }
    Console.WriteLine("\n\nAna sayfaya dönmek için herhangi bir tuşa basınız...");
    Console.ReadLine();
    RoutingHelper();

}

void InstructorGetById()
{
    int id;
    Console.Write("\nEğitmen Id: ");
    id = Convert.ToInt32(Console.ReadLine());

    var result = instructorManager.GetById(id);

    Console.WriteLine("Id: " + result.Id + "\nEğitmen Adı: " + result.FirstName + " " + result.LastName + "\nEğitmen TC: " + result.IdentityNumber + "\n");

    Console.WriteLine("\n\nAna sayfaya dönmek için herhangi bir tuşa basınız...");
    Console.ReadLine();
    RoutingHelper();
}







void CategoryOperation()
{
    int choise;
    Console.WriteLine("------------------ Kategori İşlemleri ------------------");
    Console.WriteLine("\n1-Kategori  Ekle");
    Console.WriteLine("2-Kategori  Güncelle");
    Console.WriteLine("3-Kategori  Sil");
    Console.WriteLine("4-Kategorileri  Listele");
    Console.WriteLine("5-Kategori  Arama(ID)");
    Console.Write("\nSeçiminiz: ");
    choise = Convert.ToInt32(Console.ReadLine());
    switch (choise)
    {
        case 1:
            CategoryAdd();
            break;
        case 2:
            CategoryUpdate();
            break;
        case 3:
            CategoryDelete();
            break;
        case 4:
            CategoryGetAll();
            break;
        case 5:
            CategoryGetById();
            break;
        default:
            break;
    }
}

void CategoryAdd()
{
    string name; int id;
    Console.WriteLine("------------------ Kategori Ekle ------------------");

    Console.Write("Kategori Id: ");
    id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Kategori Adı: ");
    name = Console.ReadLine();

    Category category = new Category() { Id = id, Name = name };

    categoryManager.Add(category);
    Console.WriteLine("Kategori başarıyla eklendi !");
    RoutingHelper();

}
void CategoryUpdate()
{
    string name; int id;

    Console.WriteLine("------------------ Kategori Güncelle ------------------");
    Console.Write("\nKategori Id: ");
    id = Convert.ToInt32(Console.ReadLine());
    Console.Write("\nKategori Adı: ");
    name = Console.ReadLine();

    Category category = new Category() { Id = id, Name = name };

    categoryManager.Update(category);
    Console.WriteLine("Kategori başarıyla güncellendi !");
    RoutingHelper();

}

void CategoryDelete()
{
    int id;

    Console.WriteLine("------------------ Kategori Sil ------------------");

    Console.Write("\nKategori Id: ");
    id = Convert.ToInt32(Console.ReadLine());

    var result = categoryManager.GetById(id);

    Category category = new Category() { Id = id, Name = result.Name };

    categoryManager.Delete(category);
    Console.WriteLine("Kategori başarıyla silindi !");
    RoutingHelper();

}

void CategoryGetAll()
{
    var result = categoryManager.GetAll();
    foreach (var item in result)
    {
        Console.WriteLine($"Id: {item.Id} Name: {item.Name} ");
    }
    Console.WriteLine("\n\nAna sayfaya dönmek için herhangi bir tuşa basınız...");
    Console.ReadLine();
    RoutingHelper();

}

void CategoryGetById()
{
    int id;
    Console.Write("\nKategori Id: ");
    id = Convert.ToInt32(Console.ReadLine());

    var result = categoryManager.GetById(id);

    Console.WriteLine($"Id: {result.Id} Name: {result.Name} ");

    Console.WriteLine("\n\nAna sayfaya dönmek için herhangi bir tuşa basınız...");
    Console.ReadLine();
    RoutingHelper();
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


