using System;
using System.Collections.Generic;
using System.Linq;
using LisbonDB47.Models;

namespace LisbonDB47
{
    internal class DbInitializer
    {
        internal static void SeedData(LisbonDbContext _context)
        {
            _context.Database.EnsureDeleted();

            _context.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing


            if (_context.Users.Count() == 0)
            {
                User admin = new User();
                admin.Name = "Admin Tomek";
                admin.Mail = "admin.tomek@gmail.com";
                admin.Password = "admintomek";
                admin.Active = true;
                _context.Users.Add(admin);
                _context.SaveChanges();
                var adminID = admin.UserID;

                admin = new User();
                admin.Name = "User 2";
                admin.Mail = "user.2@gmail.com";
                admin.Password = "user2";
                admin.Active = true;
                _context.Users.Add(admin);
                _context.SaveChanges();

                if (_context.Pois.Count() == 0)
                {
                    Poi poi = new Poi
                    {
                        Title = "Praça do Comércio",
                        Description = "The Praça do Comércio (Portuguese pronunciation: [ˈpɾasɐ du kuˈmɛɾsju]; English: Commerce Square) is located in the city of Lisbon, Portugal. Situated near the Tagus river, the square is still commonly known as Terreiro do Paço ([tɨˈʁɐjɾu du ˈpasu]; English: Palace Yard),[1] because it was the location of the Paços da Ribeira (Royal Ribeira Palace) until it was destroyed by the great 1755 Lisbon earthquake. After the earthquake, the square was completely remodeled as part of the rebuilding of the Pombaline Downtown, ordered by Sebastião José de Carvalho e Melo, 1st Marquis of Pombal, who was the Minister of the Kingdom of Portugal from 1750 to 1777, during the reign of Dom José I, King of Portugal.[2]",
                        Latitude = 38.7075293,
                        Longitude = -9.1365861,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);

                    poi = new Poi
                    {
                        Title = "Castelo de S. Jorge",
                        Description = "São Jorge Castle (Portuguese: Castelo de São Jorge; Portuguese pronunciation: [kɐʃˈtɛlu dɨ sɐ̃w̃ ˈʒɔɾʒ(ɨ)]; Saint George Castle) is a Moorish castle occupying a commanding hilltop overlooking the historic centre of the Portuguese city of Lisbon and Tagus River. The strongly fortified citadel dates from medieval period of Portuguese history, and is one of the main tourist sites of Lisbon.",
                        Latitude = 38.7139092,
                        Longitude = -9.1334762,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);

                    poi = new Poi
                    {
                        Title = "Ponte 25 de Abril",
                        Description = "The 25 de Abril Bridge (Ponte 25 de Abril, 25th of April Bridge, Portuguese pronunciation: [ˈpõt(ɨ) ˈvĩt i ˈsĩku ðɨ ɐˈβɾiɫ]) is a suspension bridge connecting the city of Lisbon, capital of Portugal, to the municipality of Almada on the left (south) bank of the Tagus river. It was inaugurated on August 6, 1966, and a train platform was added in 1999. It is often compared to the Golden Gate Bridge in San Francisco, US, because they are both suspension bridges of similar color. It was built by the American Bridge Company which constructed the San Francisco–Oakland Bay Bridge, but not the Golden Gate. With a total length of 2,277 metres (7,470 ft), it is the 32nd largest suspension bridge in the world. The upper deck carries six car lanes, while the lower deck carries a double track railway electrified at 25 kV AC. Until 1974, the bridge was named Salazar Bridge. The name \"25 de Abril\" commemorates the Carnation Revolution.",
                        Latitude = 38.6904756,
                        Longitude = -9.1773516,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);

                    poi = new Poi
                    {
                        Title = "Torre de Belém",
                        Description = "Belém Tower (Portuguese: Torre de Belém, pronounced [ˈtoʁ(ɨ) dɨ bɨˈlɐ̃ȷ̃]), or the \"Tower of St Vincent\",[1] is a fortified tower located in the civil parish of Santa Maria de Belém in the municipality of Lisbon, Portugal. It is a UNESCO World Heritage Site (along with the nearby Jerónimos Monastery)[2] because of the significant role it played in the Portuguese maritime discoveries of the era of the Age of Discoveries.[3] The tower was commissioned by King John II to be part of a defence system at the mouth of the Tagus river and a ceremonial gateway to Lisbon.[3]",
                        Latitude = 38.6916389,
                        Longitude = -9.2158002,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges();

                    foreach (Poi p in _context.Pois)
                    {
                        UserPoi userPoi = new UserPoi
                        {
                            Private = true,
                            PoiID = p.PoiID,
                            UserID = adminID,
                            DateCreated = DateTime.Now
                        };
                        _context.UserPois.Add(userPoi);
                    }
                    _context.SaveChanges();

                    int poiID = _context.Pois.Count();
                    poiID = poiID > 4 ? poiID -= 4 : 1;


                    Image image = new Image
                    {
                        Title = "My 1",
                        Url = "https://www.visitlisboa.com/sites/default/files/md-slider-image/2_33.jpg",
                        UserPoiID = poiID++,
                        DateCreated = DateTime.Now
                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 2",
                        Url = "https://www.360meridianos.com/wp-content/uploads/2014/10/Castelo-de-São-Jorge-Lisboa.jpg",
                        UserPoiID = poiID++,
                        DateCreated = DateTime.Now
                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 3",
                        Url = "https://www.bem-vindo-a-lisboa.com.br/wp-content/uploads/2017/07/tour-lisboa-belem-ponte-25-de-abril-e-cristo-rei-o-que-esperar-lisboa.jpg",
                        UserPoiID = poiID++,
                        DateCreated = DateTime.Now
                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 4",
                        Url = "http://www.patrimoniocultural.gov.pt/static/data/cache/f8/72/f872e73eef92ad2d755293b95634a4a6.jpg",
                        UserPoiID = poiID++,
                        DateCreated = DateTime.Now
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    Comment c = new Comment
                    {
                        Content = "Test 1",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        UserPoiID = 1,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Test 2",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        UserPoiID = 1,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    Like l = new Like
                    {
                        DateCreated = DateTime.Now,
                        UserPoiID = 1,
                        UserID = 1
                    };
                    _context.Likes.Add(l);

                    l = new Like
                    {
                        DateCreated = DateTime.Now,
                        UserPoiID = 1,
                        UserID = 2
                    };
                    _context.Likes.Add(l);
                    _context.SaveChanges();
                }
            }
        }
    }
}