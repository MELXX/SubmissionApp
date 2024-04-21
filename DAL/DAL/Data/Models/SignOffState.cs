using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public enum SignOffState
    {
        [JsonPropertyName("None")]
        None,
        [JsonPropertyName("Client Sign Off")]
        ClientSignOff,
        [JsonPropertyName("Full Sign Off")]
        FullSignOff
    }
}
