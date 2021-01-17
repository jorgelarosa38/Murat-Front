﻿using TiendaVirtual.BusinessLogic.Interfaces;
using TiendaVirtual.BusinessLogic.Utilities;
using TiendaVirtual.Models;
using TiendaVirtual.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaVirtual.BusinessLogic.Implementations
{
    public class WriteOperationLogic : IWriteOperationLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public WriteOperationLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> WriteOperation(WriteOperation writeOperation)
        {
            Response response = new Response();
            try
            {
                //string spe = await _unitOfWork.WriteOperation.GetStoreProcedure(writeOperation.IdOperacion);
                writeOperation.XML = AuxiliarMethods.StandardXML(writeOperation.XMLDatos);


                List<WriteOutput> list = await _unitOfWork.WriteOperation.WriteOperation(writeOperation);

                if (list.Count > 0)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
