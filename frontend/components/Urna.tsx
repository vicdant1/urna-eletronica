import axios from 'axios'
import { useEffect, useState } from 'react'
import { useRouter } from 'next/router'
import { toast } from 'react-toastify';
import styles from './urna.module.css'

interface UrnaProps
{
  className?: string
}

const Urna = ({className} : UrnaProps) => {

  const defaultCandidatoData = {
    nomeCompleto: null,
    nomeVice: null,
    legenda: null
  }

  const [numeroCandidato, setNumeroCandidato] = useState("");
  const [candidatoData, setCandidatoData] = useState(defaultCandidatoData);
  const router = useRouter();

  const fetchData = async () => {
    await axios.get(`http://localhost:5222/getCandidatoById?id=${numeroCandidato}`)
               .then(res => setCandidatoData(res.data))
               .catch(err => {
                  toast.error("Candidato não cadastrado.")
                  handleNumberClear();
               });	
  }

  const handleInputChange = (e) => {
    if(numeroCandidato.length < 2)
      setNumeroCandidato(numeroCandidato + e.target.innerText);
  }

  const handleNumberClear = () => {
    setNumeroCandidato("");
    setCandidatoData(defaultCandidatoData);
  }

  const handleVotoBanco = async () => {
    await axios.post(`http://localhost:5222/vote`, {})
               .then(() => {
                  toast.success("Voto computado com sucesso!");
                  router.push('/Confirmacao');
               })
               .catch(() => toast.error("Não foi possível computar o voto."));
  }

  const handleConfirmarVoto = async () => {
    if(numeroCandidato.length < 2)
      toast.error("Informe um número de candidato válido.");
    else
    {
      await axios.post(`http://localhost:5222/vote`, {candidatoId: numeroCandidato})
                .then( () => {
                    toast.success("Voto computado com sucesso!");
                    router.push('/Confirmacao');
                })
                .catch(() => toast.error("Não foi possível computar o voto."));
    }
  }

  useEffect(() => {
    if(numeroCandidato.length == 2)
      fetchData();
  }, [numeroCandidato]);
  
  return (
    <div className={className}>
      <div className={`row ${styles.urnaContainer}`}>
        <div className={`col-md-6 ${styles.urnaButtonContainer, styles.urnaScreen} d-flex justify-content-between flex-column`}>
          <div>
            Escolha seu candidato a prefeito.
            <div className={`d-flex align-items-center justify-content-center mt-2 ${styles.numberBox}`}>
              {numeroCandidato != "" && (
                <p>{numeroCandidato}</p>
              )}
            </div>
          </div>
          <div className={`${styles.candidatoData}`}>
            <p><b>Nome:</b> {candidatoData.nomeCompleto ?? '-'}</p>
            <p><b>Vice:</b> {candidatoData.nomeVice ?? '-'}</p>
            <p><b>Legenda:</b> {candidatoData.legenda ?? '-'}</p>            
          </div>
        </div>
        <div className={`col-md-6 ${styles.urnaButtonContainer}`}>
          <div className={styles.numberButtonContainer}>
            {[1,2,3,4,5,6,7,8,9,0].map((number) => (
              <span key={number} onClick={(e) => handleInputChange(e)}>{number}</span>
            ))}
          </div>
          <div className={`mt-4 ${styles.actionButtonContainer}`}>
            <span className='bg-warning' onClick={() => handleNumberClear()}>Limpa</span>
            <span className='bg-white' onClick={() => handleVotoBanco()}>Branco</span>
            <span className='bg-success' onClick={() => handleConfirmarVoto()}>Confirma</span>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Urna;