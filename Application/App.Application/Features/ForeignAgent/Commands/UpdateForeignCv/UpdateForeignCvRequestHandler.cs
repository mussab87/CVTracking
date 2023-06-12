using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.ForeignAgent.Commands.UpdateForeignCv { }

public class UpdateForeignCvRequestHandler : IRequestHandler<UpdateForeignCvRequest, int>
{
    readonly ICVRepository _unitOfWork;
    readonly IForeignAgentRepository _foreignAgent;
    readonly ICVStatusRepository _cvStatus;
    readonly IAttachmentRepository _attachmentRepository;
    readonly ICVAttachmentRepository _cVAttachmentRepository;
    readonly IPreviousEmploymentsRepository _PreviousEmployments;
    readonly IMapper _mapper;
    readonly ICVHRPool _cVHRPool;

    public UpdateForeignCvRequestHandler(ICVRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger, IForeignAgentRepository foreignAgent, ICVStatusRepository cvStatus, IAttachmentRepository attachmentRepository, IPreviousEmploymentsRepository previousEmployments, ICVHRPool cVHRPool, ICVAttachmentRepository cVAttachmentRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper;
        _foreignAgent = foreignAgent;
        _cvStatus = cvStatus;
        _attachmentRepository = attachmentRepository;
        _PreviousEmployments = previousEmployments;
        _cVHRPool = cVHRPool;
        _cVAttachmentRepository = cVAttachmentRepository;
    }

    public async Task<int> Handle(UpdateForeignCvRequest request, CancellationToken cancellationToken)
    {
        //get cv by cvId
        var existCvToUpdate = await _unitOfWork.GetByIdAsync((int)request.cv.Id);
        //update cv 
        request.cv.LastModifiedById = request.foreignAgentUserId;
        request.cv.LastModifiedDate = DateTime.Now;
        _mapper.Map(request.cv, existCvToUpdate, typeof(CVDto), typeof(CV));
        await _unitOfWork.UpdateAsync(existCvToUpdate);

        //var newForeignAgentCV = await _unitOfWork.AddAsync(_mapper.Map<CV>(request.cv));
        var foreign = await _foreignAgent.GetByIdAsync(request.foreignAgentId);
        var status = await _cvStatus.GetByIdAsync(request.cvStatusId);

        //update HRPool status
        var existHRPoolToUpdate = await _cVHRPool.GetByIdAsync(request.HRPoolId);
        existHRPoolToUpdate.LastModifiedById = request.foreignAgentUserId;
        existHRPoolToUpdate.LastModifiedDate = DateTime.Now;
        existHRPoolToUpdate.CVStatus = status;
        await _cVHRPool.UpdateAsync(existHRPoolToUpdate);

        //update PreviousEmployments
        if (request.previousEmployment != null)
        {
            await addUpdatePreviousEmployment(request, existCvToUpdate);
        }

        //add attachments
        if (request.cvAttachments.Count > 0)
        {
            await AddUpdateCvAttachments(request, existCvToUpdate);
        }

        return existCvToUpdate.Id;
    }

    private async Task AddUpdateCvAttachments(UpdateForeignCvRequest request, CV existCvToUpdate)
    {
        //get old attachments
        List<CVAttachment> oldAttachments = new();
        try
        {
            oldAttachments = _cVAttachmentRepository.GetAsync(predicate: p => p.CVId == request.cv.Id).Result.ToList();
        }
        catch (Exception)
        { }

        if (oldAttachments.Count > 0 && oldAttachments is not null)
        {
            //delete all old attachments
            foreach (var attachment in oldAttachments)
            {
                await _cVAttachmentRepository.DeleteAsync(attachment);
                await _attachmentRepository.DeleteAsync(await _attachmentRepository.GetByIdAsync(attachment.Id));
            }
        }

        var attachmentResult = await _attachmentRepository.AddAttachment(request.cvAttachments, request.foreignAgentUserId);
        await _attachmentRepository.AddCVAttachment(existCvToUpdate, attachmentResult, request.foreignAgentUserId);
    }

    async Task addUpdatePreviousEmployment(UpdateForeignCvRequest request, CV existCvToUpdate)
    {
        if (request.previousEmployment.Count > 0)
        {
            //delete old first
            var oldPreviousEmployment = await _PreviousEmployments.GetAsync(predicate: p => p.CV.Id == request.cv.Id);
            if (oldPreviousEmployment.Count > 0)
            {
                foreach (var prev in oldPreviousEmployment)
                {
                    await _PreviousEmployments.DeleteAsync(prev);
                }

            }
            //add new previous employment
            var previosEmployment = _PreviousEmployments.AddPreviousEmployments
                        (existCvToUpdate, request.previousEmployment, request.foreignAgentUserId);
        }
    }
}

