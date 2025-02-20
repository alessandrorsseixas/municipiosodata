using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.dto
{
    public class municipio
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("CÓDIGO DO MUNICÍPIO - TOM")]
        [BsonRequired()]

        public int CodigoMunicipioTom { get; set; }

        [BsonElement("CÓDIGO DO MUNICÍPIO - IBGE")]
        [BsonRequired()]
        public int CodigoMuniciopioIBGE { get; set; }

        [BsonElement("MUNICÍPIO - TOM")]
        [BsonRequired()]
        public string MunicipioTom { get; set; }


        [BsonElement("MUNICÍPIO - IBGE")]
        [BsonRequired()]
        public string MuniciopioIBGE { get; set; }


        [BsonElement("UF")]
        [BsonRequired()]
        public string Uf { get; set; }


    }
}
