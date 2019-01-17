using System;
using System.Collections.Generic;
using System.Linq;
using LisbonDB47.Helpers;
using LisbonDB47.Models;

namespace LisbonDB47
{
    internal class DbInitializer
    {
        internal static void SeedData(LisbonDbContext _context)
        {
            _context.Database.EnsureDeleted();//first remove databse

            _context.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing


            if (_context.Users.Count() == 0)
            {
                #region users 
                User admin = new User
                {
                    Name = "Admin Tomek",
                    Mail = "admin.tomek@gmail.com",
                    Password = SecurePasswordHasher.Hash("admintomek"),
                    Active = true
                };
                _context.Users.Add(admin);
                _context.SaveChanges();
                var adminID = admin.UserID; //1

                admin = new User
                {
                    Name = "User 2",
                    Mail = "user.2@gmail.com",
                    Password = SecurePasswordHasher.Hash("user2"),
                    Active = true
                };
                _context.Users.Add(admin);
                _context.SaveChanges(); //2

                admin = new User
                {
                    Name = "Alicja Delicja",
                    Mail = "alicja.delicja@gmail.com",
                    Password = SecurePasswordHasher.Hash("alicjadelicja"),
                    Active = true
                };
                _context.Users.Add(admin);
                _context.SaveChanges(); //3

                admin = new User
                {
                    Name = "Pedro Silva",
                    Mail = "pedro.silva2@gmail.com",
                    Password = SecurePasswordHasher.Hash("pedrosilva"),
                    Active = true
                };
                _context.Users.Add(admin);
                _context.SaveChanges(); //4

                admin = new User
                {
                    Name = "Luis Figo",
                    Mail = "luis.figo@gmail.com",
                    Password = SecurePasswordHasher.Hash("luisfigo"),
                    Active = true
                };
                _context.Users.Add(admin);
                _context.SaveChanges(); //5

                admin = new User
                {
                    Name = "Grzegorz Brzęczyszczykiewicz",
                    Mail = "grzegorz.brzeczyszczykiewicz2@gmail.com",
                    Password = SecurePasswordHasher.Hash("grzegorzbrzeczyszczykiewicz"),
                    Active = true
                };
                _context.Users.Add(admin);
                _context.SaveChanges(); //6
                #endregion
               
                if (_context.Pois.Count() == 0)
                {
                    #region pois and images
                    Poi poi = new Poi
                    {
                        Title = "Praça do Comércio",
                        Description = "The Praça do Comércio (Portuguese pronunciation: [ˈpɾasɐ du kuˈmɛɾsju]; English: Commerce Square) is located in the city of Lisbon, Portugal. Situated near the Tagus river, the square is still commonly known as Terreiro do Paço ([tɨˈʁɐjɾu du ˈpasu]; English: Palace Yard),[1] because it was the location of the Paços da Ribeira (Royal Ribeira Palace) until it was destroyed by the great 1755 Lisbon earthquake. After the earthquake, the square was completely remodeled as part of the rebuilding of the Pombaline Downtown, ordered by Sebastião José de Carvalho e Melo, 1st Marquis of Pombal, who was the Minister of the Kingdom of Portugal from 1750 to 1777, during the reign of Dom José I, King of Portugal.[2]",
                        Latitude = 38.7075293,
                        Longitude = -9.1365861,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi); //1
                    _context.SaveChanges();

                    int poiID = _context.Pois.Where(x => x.Title == "Praça do Comércio").Select(y => y.PoiID).FirstOrDefault();
                    Image image = new Image
                    {
                        Title = "My 1",
                        Url = "https://www.visitlisboa.com/sites/default/files/md-slider-image/2_33.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 1 2",
                        Url = "http://www.cm-lisboa.pt/uploads/pics/tt_address/ASC_0800-praca-do-comercio.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    Comment c = new Comment
                    {
                        Content = "I love this place !!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Omg, my favorite, greets<3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I've been there 3 times and was awesome every time!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "I recommend, 10/10!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();


                    poi = new Poi
                    {
                        Title = "Castelo de S. Jorge",
                        Description = "São Jorge Castle (Portuguese: Castelo de São Jorge; Portuguese pronunciation: [kɐʃˈtɛlu dɨ sɐ̃w̃ ˈʒɔɾʒ(ɨ)]; Saint George Castle) is a Moorish castle occupying a commanding hilltop overlooking the historic centre of the Portuguese city of Lisbon and Tagus River. The strongly fortified citadel dates from medieval period of Portuguese history, and is one of the main tourist sites of Lisbon.",
                        Latitude = 38.7139092,
                        Longitude = -9.1334762,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi); //2
                    _context.SaveChanges();

                    poiID = _context.Pois.Where(x => x.Title == "Castelo de S. Jorge").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 2",
                        Url = "https://www.360meridianos.com/wp-content/uploads/2014/10/Castelo-de-São-Jorge-Lisboa.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 3",
                        Url = "https://www.bem-vindo-a-lisboa.com.br/wp-content/uploads/2017/07/tour-lisboa-belem-ponte-25-de-abril-e-cristo-rei-o-que-esperar-lisboa.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);

                    c = new Comment
                    {
                        Content = "Must see this place when You will be in Lisbon",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Omg, my favorite, greets<3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "Not so good I expected, 6/10",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Very pretty. 2/10",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();


                    poi = new Poi
                    {
                        Title = "Ponte 25 de Abril",
                        Description = "The 25 de Abril Bridge (Ponte 25 de Abril, 25th of April Bridge, Portuguese pronunciation: [ˈpõt(ɨ) ˈvĩt i ˈsĩku ðɨ ɐˈβɾiɫ]) is a suspension bridge connecting the city of Lisbon, capital of Portugal, to the municipality of Almada on the left (south) bank of the Tagus river. It was inaugurated on August 6, 1966, and a train platform was added in 1999. It is often compared to the Golden Gate Bridge in San Francisco, US, because they are both suspension bridges of similar color. It was built by the American Bridge Company which constructed the San Francisco–Oakland Bay Bridge, but not the Golden Gate. With a total length of 2,277 metres (7,470 ft), it is the 32nd largest suspension bridge in the world. The upper deck carries six car lanes, while the lower deck carries a double track railway electrified at 25 kV AC. Until 1974, the bridge was named Salazar Bridge. The name \"25 de Abril\" commemorates the Carnation Revolution.",
                        Latitude = 38.6904756,
                        Longitude = -9.1773516,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi); //3
                    _context.SaveChanges();

                    poiID = _context.Pois.Where(x => x.Title == "Ponte 25 de Abril").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My Abril",
                        Url = "https://upload.wikimedia.org/wikipedia/commons/f/fc/25th_April_Bridge_and_boat.JPG",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);

                    c = new Comment
                    {
                        Content = "I will be there in next week, I'm so excited!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "The best place in Lisbon",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "Yeaaah, memories <3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Sooo great place!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();


                    poi = new Poi
                    {
                        Title = "Torre de Belém",
                        Description = "Belém Tower (Portuguese: Torre de Belém, pronounced [ˈtoʁ(ɨ) dɨ bɨˈlɐ̃ȷ̃]), or the \"Tower of St Vincent\",[1] is a fortified tower located in the civil parish of Santa Maria de Belém in the municipality of Lisbon, Portugal. It is a UNESCO World Heritage Site (along with the nearby Jerónimos Monastery)[2] because of the significant role it played in the Portuguese maritime discoveries of the era of the Age of Discoveries.[3] The tower was commissioned by King John II to be part of a defence system at the mouth of the Tagus river and a ceremonial gateway to Lisbon.[3]",
                        Latitude = 38.6916389,
                        Longitude = -9.2158002,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi); //4
                    _context.SaveChanges();

                    poiID = _context.Pois.Where(x => x.Title == "Torre de Belém").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My Abril",
                        Url = "https://upload.wikimedia.org/wikipedia/commons/f/fc/25th_April_Bridge_and_boat.JPG",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);

                    c = new Comment
                    {
                        Content = "I love this place !!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Omg, my favorite, greets<3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I've been there 3 times and was awesome every time!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "I recommend, 10/10!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();


                    poi = new Poi
                    {
                        Title = "Cascais",
                        Description = "Cascais is a coastal resort town in Portugal, just west of Lisbon. It’s known for its sandy beaches and busy marina. The old town is home to the medieval Nossa Senhora da Luz Fort and the Citadel Palace, a former royal retreat. Nearby is the whitewashed Nossa Senhora da Assunção church, with glazed azulejo tiles. Paula Rego House of Stories shows the Portuguese artist’s paintings in a modern building.",
                        Latitude = 38.697060,
                        Longitude = -9.422222,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges(); //5

                    poiID = _context.Pois.Where(x => x.Title == "Cascais").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 4",
                        Url = "http://www.patrimoniocultural.gov.pt/static/data/cache/f8/72/f872e73eef92ad2d755293b95634a4a6.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 5 Cascais",
                        Url = "http://nomanbefore.com/wp-content/uploads/2016/09/Cascais-9-e1497997239735.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "It'sgood place",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Worth to visit",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "Best regards to my family!!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Perfect, I felt in love",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    poi = new Poi
                    {
                        Title = "Telecabine Lisbon - North Station",
                        Description = "A trip between the river and the sky. In the heart of Lisbon on nations park. The Nations Park Gondola Lift is a means of aerial transportation by cable located in Lisbon, Portugal, intended for tourist purposes.",
                        Latitude = 38.773436,
                        Longitude = -9.091420,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges(); //6

                    poiID = _context.Pois.Where(x => x.Title == "Telecabine Lisbon - North Station").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 6 telecabine",
                        Url = "https://img1.10bestmedia.com/Images/Photos/262195/p-Cable-car_54_990x660.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 6 telecabine 2",
                        Url = "https://www.telecabinelisboa.pt/WebRoot/Store/Shops/2060-120119/MediaGallery/Categories/Uma_Viagem_no_Teleferico_em_Lisboa/Galeria_de_imagens/telecabine04.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I lost 100EUR there!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Nice, Awesome!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I've been there 5 times and was awesome every time!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Beautiful!!!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();



                    poi = new Poi
                    {
                        Title = "National Pantheon",
                        Description = "17th-century baroque church turned into modern-day mausoleum for tombs of national celebrities.",
                        Latitude = 38.714985,
                        Longitude = -9.124667,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges(); //7

                    poiID = _context.Pois.Where(x => x.Title == "National Pantheon").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 7 pantheone",
                        Url = "https://media-cdn.tripadvisor.com/media/photo-s/01/48/bc/ef/lisbon-igreja-de-santa.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 7 pantheon 2",
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/36/Pante%C3%A3o_Nacional_Mosteiro_de_Sao_Vicente_de_Fora_zoom.JPG/1200px-Pante%C3%A3o_Nacional_Mosteiro_de_Sao_Vicente_de_Fora_zoom.JPG",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "One word: awesome!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "I didnt have time to visit this place and regret so much :(",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "Must have seen, really!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Really good place",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();


                    poi = new Poi
                    {
                        Title = "Miradouro da Nossa Senhora do Monte",
                        Description = "Located in a churchyard, this highest point in the neighborhood offers panoramic views of the city.",
                        Latitude = 38.719181,
                        Longitude = -9.132832,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges(); //8

                    poiID = _context.Pois.Where(x => x.Title == "Miradouro da Nossa Senhora do Monte").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 8 ",
                        Url = "https://www.lisbonlux.com/images/lisbon/miradouro-senhora-do-monte.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 8 2",
                        Url = "https://www.lisbonlux.com/images/miradouros/miradouro-senhora-do-monte.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I love this place !!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Nice place, worth to visit",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "Sooooo pretty!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Good place!!!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    poi = new Poi
                    {
                        Title = "Santa Justa Lift",
                        Description = "Cast-iron elevator with filigree details, built in 1902 to connect lower streets with Carmo Square.",
                        Latitude = 38.712127,
                        Longitude = -9.139425,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges(); //9

                    poiID = _context.Pois.Where(x => x.Title == "Miradouro da Nossa Senhora do Monte").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 9 ",
                        Url = "https://afar-production.imgix.net/uploads/images/post_images/images/ovEHcLx6Cg/original_8._20Santa_20Justa_20Lift_20SMALL.jpg?1480622368?ixlib=rails-0.3.0&auto=format%2Ccompress&crop=entropy&fit=crop&h=719&q=80&w=954",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 9 2",
                        Url = "https://cdn1.gbot.me/photos/aQ/bM/1526872518/Elevador_de_Santa_Justa-Elevador_de_Santa_Justa-20000000016228980-500x375.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I love this place !!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Omg, my favorite, greets<3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I've been there 3 times and was awesome every time!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "I recommend, 10/10!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 5
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    poi = new Poi
                    {
                        Title = "Miradouro Sophia de Mello Breyner Andresen",
                        Description = "This popular terrace offers dramatic, panoramic views of city rooftops & the water beyond.",
                        Latitude = 38.716272,
                        Longitude = -9.131524,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges(); //10

                    poiID = _context.Pois.Where(x => x.Title == "Miradouro da Nossa Senhora do Monte").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 10 ",
                        Url = "https://www.playocean.net/i/portugal/lisboa/miradouros/miradouro-sophia-de-mello-breyner-andresen/miradouro-sophia-de-mello-breyner-andresen-1.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 10 2",
                        Url = "https://www.lavanguardia.com/r/GODO/LV/p5/WebSite/2018/05/08/Recortada/img_lbernaus_20180508-170907_imagenes_lv_terceros_miradouro_da_graca-by-filipe-rocha---from-wikimedia-commons-knCB--656x437@LaVanguardia-Web.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I love this place !!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 5
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Omg, my favorite, really<3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "11/10",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "I loveee!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();


                    poi = new Poi
                    {
                        Title = "Carmo Convent",
                        Description = "Ruined Gothic church destroyed by an earthquake in 1755, with an evocative roofless nave & museum.",
                        Latitude = 38.712139,
                        Longitude = -9.140244,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges(); //11

                    poiID = _context.Pois.Where(x => x.Title == "Carmo Convent").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 11 ",
                        Url = "https://media-cdn.tripadvisor.com/media/photo-s/04/41/55/f8/igreja-do-carmo.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 11 2",
                        Url = "https://www.askmelisboa.com/media/catalog/product/m/u/museu-carmo-6984.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I love this place !!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 4
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Omg, my favorite, greets<3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I've been there 3 times and was awesome every time!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "I recommend, 10/10!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();


                    poi = new Poi
                    {
                        Title = "Escultura de Fernando Pessoa",
                        Description = "Este grande escritor e poeta do séc. XX encontra-se imortalizado numa estátua de bronze, que o recorda sentado familiarmente numa mesa do Café A Brasileira, ao Chiado, onde muitas vezes escrevia os seus textos e filosofava com os seus amigos sobre a época em que vivia. Obra do escultor Lagoa Henriques, foi inaugurada na década de 80.",
                        Latitude = 38.710614,
                        Longitude = -9.142101,
                        Private = false,
                        UserID = adminID,
                        DateCreated = DateTime.Now
                    };
                    _context.Pois.Add(poi);
                    _context.SaveChanges(); //12

                    poiID = _context.Pois.Where(x => x.Title == "Escultura de Fernando Pessoa").Select(y => y.PoiID).FirstOrDefault();
                    image = new Image
                    {
                        Title = "My 12 ",
                        Url = "http://www.cm-lisboa.pt/uploads/pics/tt_address/lxi-3015-01.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID

                    };
                    _context.Images.Add(image);

                    image = new Image
                    {
                        Title = "My 12 2",
                        Url = "https://media-cdn.tripadvisor.com/media/photo-s/09/f6/cf/81/escultura-de-fernando.jpg",
                        DateCreated = DateTime.Now,
                        PoiID = poiID
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I love this place !!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "Omg, my favorite, greets<3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 1
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();

                    c = new Comment
                    {
                        Content = "I've been there 3 times and was awesome every time!!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 2
                    };
                    _context.Comments.Add(c);

                    c = new Comment
                    {
                        Content = "I recommend, 10/10!",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = poiID,
                        UserID = 3
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();


                    //int poiID = _context.Pois.Count();
                    //poiID = poiID > 5 ? poiID -= 5 : 1;
                    #endregion

                    #region comments

                    c = new Comment
                    {
                        Content = "Omg, my favorite, greets<3",
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        PoiID = 1,
                        UserID = 2
                    };
                    _context.Comments.Add(c);
                    _context.SaveChanges();
                    #endregion

                    #region likes
                    Like l = new Like
                    {
                        DateCreated = DateTime.Now,
                        PoiID = 1,
                        UserID = 1
                    };
                    _context.Likes.Add(l);

                    l = new Like
                    {
                        DateCreated = DateTime.Now,
                        PoiID = 1,
                        UserID = 2
                    };
                    _context.Likes.Add(l);
                    _context.SaveChanges();
                    #endregion
                }
            }
        }
    }
}