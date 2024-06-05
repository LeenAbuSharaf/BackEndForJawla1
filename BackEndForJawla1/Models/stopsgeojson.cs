using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;


namespace BackEndForJawla1.Models
{
    public class stopsgeojson
    {

        [Key]
        public int Id { get; set; }

        public Point geom {  get; set; }

        
        public string StopID { get; set; }

        public int StopName { get; set; }
    }
}
