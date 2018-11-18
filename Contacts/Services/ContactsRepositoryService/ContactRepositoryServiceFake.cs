﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Services.ContactsRepositoryService
{
    //Temporary implementation of IContactRepositoryService cause it operates with fake data
    public class ContactRepositoryServiceFake : IContactRepositoryService
    {
        public List<Contact> GetAll()
        {
            return ReadContacts();
        }

        private List<Contact> ReadContacts()
        {
            return new List<Contact>
            {
                new Contact{FirstName="Илон",LastName="Маск",Email="Ilon.mask@mail.com",
                    Notes ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur pharetra dictum nibh vel ornare. Donec sem urna, rhoncus sed cursus ac, aliquet at nisl. Pellentesque cursus et lacus vel porta. Morbi iaculis efficitur volutpat. Curabitur sit amet cursus nisl, ac suscipit mauris. Nulla a tellus a odio tincidunt maximus. Maecenas non eros lacus. Donec aliquam libero nec ex ullamcorper, in lobortis nibh dapibus. Mauris vehicula, tellus quis congue tincidunt, neque massa auctor ante, ut laoreet felis nisi id tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc sed dapibus quam, in viverra arcu. Vivamus ut metus non magna viverra porttitor a ultrices dui.",
                    PathToImage = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/4/49/Elon_Musk_2015.jpg/267px-Elon_Musk_2015.jpg")},
                new Contact{FirstName="Лев",LastName="Яшин",Email="Lev.yashin@mail.com",
                    Notes ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur pharetra dictum nibh vel ornare. Donec sem urna, rhoncus sed cursus ac, aliquet at nisl. Pellentesque cursus et lacus vel porta. Morbi iaculis efficitur volutpat. Curabitur sit amet cursus nisl, ac suscipit mauris. Nulla a tellus a odio tincidunt maximus. Maecenas non eros lacus. Donec aliquam libero nec ex ullamcorper, in lobortis nibh dapibus. Mauris vehicula, tellus quis congue tincidunt, neque massa auctor ante, ut laoreet felis nisi id tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc sed dapibus quam, in viverra arcu. Vivamus ut metus non magna viverra porttitor a ultrices dui.",
                    PathToImage =new Uri ("https://secrethistory.su/uploads/posts/2014-02/1391712110_lev-yashin.jpg")},
                new Contact{FirstName="Кристиан",LastName="Стюарт",Email="Kristen.stewart@mail.com",
                    Notes ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur pharetra dictum nibh vel ornare. Donec sem urna, rhoncus sed cursus ac, aliquet at nisl. Pellentesque cursus et lacus vel porta. Morbi iaculis efficitur volutpat. Curabitur sit amet cursus nisl, ac suscipit mauris. Nulla a tellus a odio tincidunt maximus. Maecenas non eros lacus. Donec aliquam libero nec ex ullamcorper, in lobortis nibh dapibus. Mauris vehicula, tellus quis congue tincidunt, neque massa auctor ante, ut laoreet felis nisi id tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc sed dapibus quam, in viverra arcu. Vivamus ut metus non magna viverra porttitor a ultrices dui.",
                    PathToImage = new Uri ("https://my-hit.org/storage/1875060_500x800x250.jpg")},
                new Contact{FirstName="Райан",LastName="Гослинг",Email="Ryan.gosling@mail.com",
                    Notes ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur pharetra dictum nibh vel ornare. Donec sem urna, rhoncus sed cursus ac, aliquet at nisl. Pellentesque cursus et lacus vel porta. Morbi iaculis efficitur volutpat. Curabitur sit amet cursus nisl, ac suscipit mauris. Nulla a tellus a odio tincidunt maximus. Maecenas non eros lacus. Donec aliquam libero nec ex ullamcorper, in lobortis nibh dapibus. Mauris vehicula, tellus quis congue tincidunt, neque massa auctor ante, ut laoreet felis nisi id tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc sed dapibus quam, in viverra arcu. Vivamus ut metus non magna viverra porttitor a ultrices dui.",
                    PathToImage =new Uri("http://games-of-thrones.ru/sites/default/files/pictures/all/gosling/31.jpg")},
                new Contact{FirstName="Том", LastName="Хидделстон", Email="Tom.hiddleston@mail.com",
                    Notes ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur pharetra dictum nibh vel ornare. Donec sem urna, rhoncus sed cursus ac, aliquet at nisl. Pellentesque cursus et lacus vel porta. Morbi iaculis efficitur volutpat. Curabitur sit amet cursus nisl, ac suscipit mauris. Nulla a tellus a odio tincidunt maximus. Maecenas non eros lacus. Donec aliquam libero nec ex ullamcorper, in lobortis nibh dapibus. Mauris vehicula, tellus quis congue tincidunt, neque massa auctor ante, ut laoreet felis nisi id tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc sed dapibus quam, in viverra arcu. Vivamus ut metus non magna viverra porttitor a ultrices dui.",
                    PathToImage =new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/b/bc/Tom_Hiddleston_by_Gage_Skidmore_3.jpg/267px-Tom_Hiddleston_by_Gage_Skidmore_3.jpg") },
                new Contact{FirstName="Килиан",LastName="Мёрфи",Email="Cilian.murphy@mail.com",
                    Notes ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur pharetra dictum nibh vel ornare. Donec sem urna, rhoncus sed cursus ac, aliquet at nisl. Pellentesque cursus et lacus vel porta. Morbi iaculis efficitur volutpat. Curabitur sit amet cursus nisl, ac suscipit mauris. Nulla a tellus a odio tincidunt maximus. Maecenas non eros lacus. Donec aliquam libero nec ex ullamcorper, in lobortis nibh dapibus. Mauris vehicula, tellus quis congue tincidunt, neque massa auctor ante, ut laoreet felis nisi id tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc sed dapibus quam, in viverra arcu. Vivamus ut metus non magna viverra porttitor a ultrices dui.",
                    PathToImage =new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/0/04/Cillian_Murphy_2014_cropped.jpg/1200px-Cillian_Murphy_2014_cropped.jpg")}
            };
        }

    }
}
