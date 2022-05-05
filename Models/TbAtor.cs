﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIFILMES.Models
{
    [Table("tb_ator")]
    public partial class TbAtor
    {
        public TbAtor()
        {
            TbFilmeAtors = new HashSet<TbFilmeAtor>();
        }

        [Key]
        [Column("id_ator")]
        public int IdAtor { get; set; }
        [Column("nm_ator")]
        [StringLength(100)]
        public string NmAtor { get; set; } = null!;
        [Column("vl_altura")]
        [Precision(10, 2)]
        public decimal? VlAltura { get; set; }
        [Column("dt_nascimento")]
        public DateOnly? DtNascimento { get; set; }

        [InverseProperty("IdAtorNavigation")]
        public virtual ICollection<TbFilmeAtor> TbFilmeAtors { get; set; }
    }
}
