using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title {  get; set; }
        public string? Author {  get; set; }
        public string? Category { get; set; }
        public string? Publisher { get; set; }
        public string? PublishDate { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
