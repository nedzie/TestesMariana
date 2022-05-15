using TestesMariana.Dominio.Compartilhado;

namespace TestesMariana.Dominio.ModuloQuestao
{
    public class Alternativa : EntidadeBase<Alternativa>
    {
        public string Opcao { get; set; }
        public bool EstaCerta { get; set; }

        public override void Atualizar(Alternativa registro)
        {
            this.Opcao = registro.Opcao;
            this.EstaCerta = registro.EstaCerta;
        }

        public override string ToString()
        {
            return Opcao;
        }
    }
}
