import { NextPage } from "next";
import style from './cadastro.module.css'
import Link from "next/link";
import { FaPlusCircle, FaTrashAlt } from "react-icons/fa";
import { toast } from 'react-toastify';
import axios from 'axios';
import { useEffect, useState } from "react";

const Cadastro: NextPage = () => {
  const defaultCandidatoData = {
    NomeCompleto: "",
    NomeVice: "",
    Legenda: 1
  }

  const [candidatos, setCandidatos] = useState<any[]>([]);
  const [candidato, setCandidato] = useState(defaultCandidatoData);

  const fetchData = async () => {
    return await axios.get('http://localhost:5222/votes')
      .then(res => setCandidatos(res.data))
      .catch(err => console.log(err));
  }

  const cadastrarCandidato = async () => {
    await axios.post('http://localhost:5222/candidate', candidato)
      .then(() => {
        $('#modalCadastro').modal('hide');
        fetchData();
        toast.success("Candidato cadastrado com sucesso!");
      })
      .catch(() => {
        toast.error("Não foi possível cadastrar o candidato.");
      });
  }

  const deleteCandidato = async (id:number) => {
    await axios.delete(`http://localhost:5222/candidate/${id}`)
      .then(() => {
        fetchData();
        toast.success("Candidato excluído com sucesso!");
      })
      .catch(() => {
        toast.error("Não foi possível excluir o candidato.");
      });
  }
  
  const cleanCandidatoObject = () => {
    setCandidato(defaultCandidatoData);
  }

  const handleInputChange = (e) => {
    setCandidato({
      ...candidato,
      [e.target.name]: e.target.value
    })
  }  

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <>
      <main className="mt-4">
        <h2 className="text-center">Candidatos</h2>
        
        <div className="container">
          <div className="row">
            <div className="col-md-12 d-flex justify-content-end">
              <button className="btn btn-dark" data-bs-toggle="modal" data-bs-target="#modalCadastro"><FaPlusCircle/> Candidato</button>
            </div>
          </div>

        {candidatos.length > 0 ? 
        (
          <table className="table table-striped mt-4">
            <thead>
              <tr>
                <th scope="col">Número</th>
                <th scope="col">Nome</th>
                <th scope="col">Vice</th>
                <th scope="col" className="text-center">Legenda</th>
                <th scope="col" className="text-center">Ações</th>
              </tr>
            </thead>
            <tbody>
              {candidatos.map((candidato, index) => (
                <tr key={index}>
                  <th scope="row">{candidato.id}</th>
                  <td>{candidato.nomeCompleto}</td>
                  <td>{candidato.nomeVice}</td>
                  <td className="text-center">{candidato.legenda}</td>
                  <td className="text-center">
                    <button className="btn" onClick={() => deleteCandidato(candidato.id)}>
                      <FaTrashAlt/>
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>)
        : (
        <div className={`${style.emptyPage}`}>
          <h5 className="text-center text-muted">Não há candidatos cadastrados na eleição. <hr />
            <Link href='/'>Voltar</Link>
          </h5>
        </div>)}
        </div>
      </main>

      <div className="modal fade" id="modalCadastro" data-bs-backdrop="static" data-bs-keyboard="false" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title" id="staticBackdropLabel">Cadastro de candidatos</h5>
            </div>
            <div className="modal-body">
            <form>
              <div className="mb-3">
                <label htmlFor="NomeCompleto" className="form-label">Nome completo</label>
                <input name="NomeCompleto" onChange={(e) => handleInputChange(e)} value={candidato.NomeCompleto} type="text" className="form-control" placeholder="Kurt Cobain" required/>
              </div>
              <div className="mb-3">
                <label htmlFor="NomeVice" className="form-label">Nome do vice</label>
                <input name="NomeVice" onChange={(e) => handleInputChange(e)} value={candidato.NomeVice} type="text" className="form-control" placeholder="Dave Grohl" required/>
              </div>
              <div className="mb-3">
                <label htmlFor="Legenda" className="form-label">Legenda</label>
                <input name="Legenda" onChange={(e) => handleInputChange(e)} value={candidato.Legenda} type="number" min="1" className="form-control" required/>
              </div>
            </form>
            </div>
            <div className="modal-footer">
              <button type="button" onClick={() => cleanCandidatoObject()} className="btn btn-danger" data-bs-dismiss="modal">Fechar</button>
              <button type="button" onClick={() => cadastrarCandidato()} className="btn btn-dark">Cadastrar</button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Cadastro;