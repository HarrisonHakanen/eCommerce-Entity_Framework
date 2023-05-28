using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{

    [Index(nameof(Email),IsUnique =true,Name ="IX_EMAIL_UNICO")]
    [Index(nameof(Nome),nameof(Sexo))]
    [Table("TB_USUARIOS")]
    public class Usuario
    {

        /*
        [Key]
        [Column("COD")]
        public int Codigo { get; set; } 
        */
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }     

        public string Nome { get; set; } = null!;


        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        public string? Sexo { get; set; }

        [Column("REGISTRO_GERAL")]
        public string? RG { get; set; }

        public string CPF { get; set; } = null!;

        public string? Mae { get; set; }

        public string? SituacaoCadastro { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Matricula { get; set; }
        /*
         * RegistroAtivo = (SituacaoCadastro=="ATIVO")?True:False
         * Melhor visualizacao no Software/Aplicativo - Nao precisa ser persistido       
         */
        [NotMapped]
        public bool RegistroAtivo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset DataCadastro { get; set; }  //Vai ser gerenciado pelo banco utilizando o GetDate() no banco

        [ForeignKey("UsuarioId")]
        public Contato? Contato { get; set; }

        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }

        public ICollection<Departamento>? Departamentos { get; set; }

        //Aponta para o objeto e nao para o atributo ClienteId
        [InverseProperty("Cliente")]
        public ICollection<Pedido>? PedidosCompradosPeloCliente { get; set;}

        [InverseProperty("Colaborador")]
        public ICollection<Pedido>? PedidosGerenciadosPeloColaborador { get; set; }

        [InverseProperty("Supervisor")]
        public ICollection<Pedido>? PedidosSupervisionadosPeloSupervisor { get; set; }

    }
}
