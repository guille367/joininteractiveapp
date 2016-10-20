using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActorsProject.Models
{
    public class Actor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string bio { get; set; }
        public string picture { get; set; }

        public Actor()
        { }

        public Actor(int id, string name, string bio, string picture)
        {
            this.id = id;
            this.name = name;
            this.bio = bio;
            this.picture = picture;
        }
    }
}