﻿using Raffle.Domain.DTO_s.AssignedNumber;

namespace Domain.Test.DataBuilder.DTO_s
{
    public class AssignedNumberCreateRequestDtoBuilder
    {
        private Guid _productId;
        private Guid _userId;

        public AssignedNumberCreateRequestDtoBuilder()
        {
            _productId = Guid.NewGuid();
            _userId = Guid.NewGuid();
        }

        public AssignedNumberCreateRequestDto Build()
        {
            return new AssignedNumberCreateRequestDto
            {
                ProductId = _productId,
                UserId = _userId
            };
        }

        public AssignedNumberCreateRequestDtoBuilder WithProductId(Guid productId)
        {
            _productId = productId;
            return this;
        }

        public AssignedNumberCreateRequestDtoBuilder WithUserId(Guid userId)
        {
            _userId = userId;
            return this;
        }
    }
}
