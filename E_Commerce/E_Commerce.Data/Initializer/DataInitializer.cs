using E_Commerce.Data.Data;
using E_Commerce.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce.Data.Initializer
{
    public class DataInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<CategoryEntity>(){
                        new CategoryEntity()
                        {
                            Name = "Giyim"
                        },
                        new CategoryEntity()
                        {
                            Name = "Ayakkabı & Çanta"
                        },
                        new CategoryEntity()
                        {
                            Name = "Aksesuar"
                        },
                        new CategoryEntity()
                        {
                            Name = "Kozmetik"
                        },
                        new CategoryEntity()
                        {
                            Name = "Spor & Outdoor"
                        },
                        new CategoryEntity()
                        {
                            Name = "Elektronik"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<ProductEntity>()
                    {
                        new ProductEntity()
                        {
                            Name="Kırmızı Elbise",
                            Price=150,
                            PictureURL="https://images.unsplash.com/photo-1595777457583-95e059d581b8?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=483&q=80",
                            Total=100,
                            Details="Özel günler için kırmızı elbise",
                            CategoryId=1
                        },
                        new ProductEntity()
                        {
                            Name="Yeşil Elbise",
                            Price=250,
                            PictureURL="https://images.unsplash.com/flagged/photo-1585052201332-b8c0ce30972f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=435&q=80",
                            Total=100,
                            Details="Özel günler için yeşil elbise",
                            CategoryId=1
                        },
                        new ProductEntity()
                        {
                            Name="Yırtık Jean",
                            Price=80,
                            PictureURL="https://images.unsplash.com/photo-1541099649105-f69ad21f3246?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80",
                            Total=120,
                            Details="Rahat jean",
                            CategoryId=1
                        },
                        new ProductEntity()
                        {
                            Name="Günlük Sırt Çantası",
                            Price=250,
                            PictureURL="https://images.unsplash.com/photo-1581605405669-fcdf81165afa?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80",
                            Total=1020,
                            Details="Sağlam ve şık sırt çantası",
                            CategoryId=2
                        },
                        new ProductEntity()
                        {
                            Name="Rahat Günlük Spor Ayakkabı",
                            Price=1000,
                            PictureURL="https://images.unsplash.com/photo-1560769629-975ec94e6a86?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=464&q=80",
                            Total=100,
                            Details="Rahat Günlük Spor Ayakkabı",
                            CategoryId=2
                        },
                        new ProductEntity()
                        {
                            Name="Topuklu Ayakkabı",
                            Price=1500,
                            PictureURL="https://images.unsplash.com/photo-1543163521-1bf539c55dd2?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80",
                            Total=20,
                            Details="Özel tasarım ayakkabı",
                            CategoryId=2
                        },
                        new ProductEntity()
                        {
                            Name="Sade Kolyeler (2li)",
                            Price=2500,
                            PictureURL="https://images.unsplash.com/photo-1611652022419-a9419f74343d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=388&q=80",
                            Total=120,
                            Details="Sade ve şık kolyeler",
                            CategoryId=3
                        },
                        new ProductEntity()
                        {
                            Name="Güneş Gözlüğü",
                            Price=500,
                            PictureURL="https://images.unsplash.com/photo-1599838082471-71ca4aa8e0c8?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                            Total=10,
                            Details="Şık güneş gözlüğü",
                            CategoryId=3
                        },
                        new ProductEntity()
                        {
                            Name="Saat",
                            Price=1500,
                            PictureURL="https://images.unsplash.com/photo-1623998021450-85c29c644e0d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=957&q=80",
                            Total=500,
                            Details="Saat",
                            CategoryId=3
                        },
                        new ProductEntity()
                        {
                            Name="Makyaj Fırçaları (Set)",
                            Price=150,
                            PictureURL="https://images.unsplash.com/photo-1515688594390-b649af70d282?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=806&q=80",
                            Total=120,
                            Details="Makyaj Fırçaları",
                            CategoryId=4
                        },
                        new ProductEntity()
                        {
                            Name="Far Paleti",
                            Price=500,
                            PictureURL="https://images.unsplash.com/photo-1596704017254-9b121068fb31?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=435&q=80",
                            Total=100,
                            Details="Far Paleti",
                            CategoryId=4
                        },
                        new ProductEntity()
                        {
                            Name="5'li Ruş Seti",
                            Price=300,
                            PictureURL="https://images.unsplash.com/photo-1571646034647-52e6ea84b28c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=80",
                            Total=200,
                            Details="5'li Ruş Seti",
                            CategoryId=4
                        },
                        new ProductEntity()
                        {
                            Name="Egzersiz Gereçleri (Mini Set)",
                            Price=150,
                            PictureURL="https://images.unsplash.com/photo-1591291621164-2c6367723315?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80",
                            Total=120,
                            Details="Egzersiz Gereçleri (Mini Set)",
                            CategoryId=5
                        },
                        new ProductEntity()
                        {
                            Name="Tenis Paleti ve Topu",
                            Price=500,
                            PictureURL="https://images.unsplash.com/photo-1542144582-1ba00456b5e3?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=478&q=80",
                            Total=1000,
                            Details="Tenis Paleti ve Topu",
                            CategoryId=5
                        },
                        new ProductEntity()
                        {
                            Name="Direnç Lastiği",
                            Price=200,
                            PictureURL="https://images.unsplash.com/photo-1609351043093-551ff5c5c632?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                            Total=2000,
                            Details="Direnç Lastiği",
                            CategoryId=5
                        },
                        new ProductEntity()
                        {
                            Name="Laptop",
                            Price=25000,
                            PictureURL="https://images.unsplash.com/photo-1525547719571-a2d4ac8945e2?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=464&q=80",
                            Total=120,
                            Details="Laptop",
                            CategoryId=6
                        },
                        new ProductEntity()
                        {
                            Name="Telefon",
                            Price=12000,
                            PictureURL="https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80",
                            Total=1000,
                            Details="Telefon",
                            CategoryId=6
                        },
                        new ProductEntity()
                        {
                            Name="Kulaklık",
                            Price=800,
                            PictureURL="https://images.unsplash.com/photo-1484704849700-f032a568e944?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                            Total=2000,
                            Details="Kulaklık",
                            CategoryId=6
                        }
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
