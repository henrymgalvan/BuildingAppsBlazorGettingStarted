﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AnimalShelter.Shared;

namespace AnimalShelter.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private List<Product> Products { get; set; } = new List<Product>();

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var response = await _httpClient.GetFromJsonAsync<Product[]>("api/Product");
            return response.ToList();

        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
        }

        public async Task DeleteProduct(Product product)
        {
            await _httpClient.DeleteAsync($"api/Product/{product.Id}");
        }

        public async Task AddProduct(Product newProduct)
        {
            await _httpClient.PostAsJsonAsync<Product>("api/Product", newProduct);
        }

        public async Task UpdateProduct(Product product)
        {
            await _httpClient.PutAsJsonAsync<Product>($"api/Product/{product.Id}", product);
        }
    }
}
