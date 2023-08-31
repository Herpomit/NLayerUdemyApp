﻿using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitofWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitofWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomeResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomeResponseDto<List<ProductWithCategoryDto>>.Success(200, productDto);
        }
    }
}
