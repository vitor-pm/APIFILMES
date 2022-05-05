using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIFILMES.Models
{
    [Table("tb_diretor")]
    public partial class TbDiretor
    {
        public TbDiretor()
        {
            TbFilmes = new HashSet<TbFilme>();
        }

        [Key]
        [Column("id_diretor")]
        public int IdDiretor { get; set; }
        [Column("nm_diretor")]
        [StringLength(100)]
        public string NmDiretor { get; set; } = null!;
        [Column("dt_nascimento")]
        public DateOnly? DtNascimento { get; set; }

        [InverseProperty("IdDiretorNavigation")]
        public virtual ICollection<TbFilme> TbFilmes { get; set; }
    }
}
