using System.Text.Json.Serialization;

// Defines a model for exchange rate data with properties mapped to specific JSON properties expected from an API response.
namespace HnbApiProject.Models
{
    public class ExchangeRate
    {
        [JsonPropertyName("broj_tecajnice")]
        public string BrojTecajnice { get; set; }

        [JsonPropertyName("datum_primjene")]
        public string DatumPrimjene { get; set; }

        [JsonPropertyName("drzava")]
        public string Drzava { get; set; }

        [JsonPropertyName("drzava_iso")]
        public string DrzavaIso { get; set; }

        [JsonPropertyName("kupovni_tecaj")]
        public string KupovniTecaj { get; set; }

        [JsonPropertyName("prodajni_tecaj")]
        public string ProdajniTecaj { get; set; }

        [JsonPropertyName("sifra_valute")]
        public string SifraValute { get; set; }

        [JsonPropertyName("srednji_tecaj")]
        public string SrednjiTecaj { get; set; }

        [JsonPropertyName("valuta")]
        public string Valuta { get; set; }
    }
}
