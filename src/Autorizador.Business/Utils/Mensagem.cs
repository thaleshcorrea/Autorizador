namespace Autorizador.Business.Utils
{
    public static class ClienteMensagem
    {
        public static string JaExisteClienteCadastradoNesseCpfCnpj => "Já existe um cliente cadastrado com o CPF/CNPJ informado.";
        public static string ClienteComRegistrosVinculados => "Cliente já possui registros vinculados.\nNão foi possivel remover.";
    }

    public static class AplicativoMensagem
    {
        public static string JaExisteUmAplicativoComEsseIdentificador => "Identificador já usado por outro aplicativo.";
        public static string AplicativoPossuiClienteVinculados => "Já existe clientes vinculados ao aplicativo.";
    }
}
