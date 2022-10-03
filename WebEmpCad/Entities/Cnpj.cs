namespace WebEmpCad.Entities
{
    public class HandleCnpj
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Cnpj { get; set; }

        public bool Verificacao = false;
    }
}
