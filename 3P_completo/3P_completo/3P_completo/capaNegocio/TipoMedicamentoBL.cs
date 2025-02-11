using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class TipoMedicamentoBL
    {
        public List<TipoMedicamentoCLS> listarMedicamentos()
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();

            return obj.listarTipoMedicamento();
        }

        public List<UsuarioCLS> listarUsuarios()
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();

            return obj.listarUsuarios();
        }
    }


}
