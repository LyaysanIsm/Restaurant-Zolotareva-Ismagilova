using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Enums;
using RestaurantBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BusinessLogics
{
    public class SupplierBusinessLogic
    {
        private readonly IRequestLogic requestLogic;
        public SupplierBusinessLogic(IRequestLogic requestLogic)
        {
            this.requestLogic = requestLogic;
        }

        public void AcceptRequest(ChangeRequestStatusBindingModel model)
        {
            var request = requestLogic.Read(new RequestBindingModel
            {
                Id = model.RequestId
            })?[0];
            if (request == null)
            {
                throw new Exception("Request not found");
            }
            if (request.Status != RequestStatus.Created)
            {
                throw new Exception("Request is not in status \"Created\"");
            }
            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Id = request.Id,
                SupplierId = request.SupplierId,
                Status = RequestStatus.Processed,
                Foods = request.Foods
            });
        }

        public void CompleteRequest(ChangeRequestStatusBindingModel model)
        {
            var request = requestLogic.Read(new RequestBindingModel
            {
                Id = model.RequestId
            })?[0];
            if (request == null)
            {
                throw new Exception("Request not found");
            }
            if (request.Status != RequestStatus.Processed)
            {
                throw new Exception("Request is not in status \"Processed\"");
            }
            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Id = request.Id,
                SupplierId = request.SupplierId,
                Status = RequestStatus.Executed,
                Foods = request.Foods
            });
        }
    }
}