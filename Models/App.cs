using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aiursoft.Pylon.Services;

namespace Echeers.Mq.Models
{
    public class App
    {
        [Obsolete(error: true, message: "This method is only for framework!")]
        public App() { }
        public App(string seed, string name)
        {
            this.Id = (seed + DateTime.Now.ToString()).GetMD5();
            this.Secret = (seed + this.Id + DateTime.Now.ToString() + StringOperation.RandomString(15)).GetMD5();
        }
        public string Id { get; set; }
        public string Secret { get; set; }
        [Required]
        public string Name { get; set; }

        public string OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public MqUser Owner { get; set; }

    }
}