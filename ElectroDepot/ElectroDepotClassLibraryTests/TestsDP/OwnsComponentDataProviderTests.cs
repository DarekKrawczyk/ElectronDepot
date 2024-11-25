﻿using ElectroDepotClassLibrary.DTOs;
using ElectroDepotClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.Tests
{
    public class OwnsComponentDataProviderTests : BaseDataProviderTest
    {
        public OwnsComponentDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public async Task Create()
        {
            try
            {
                IEnumerable<User> allUsers = await UserDP.GetAllUsers();
                Assert.NotNull(allUsers);
                Assert.NotEmpty(allUsers);
                User foundUser = allUsers.FirstOrDefault();
                Assert.NotNull(foundUser);

                IEnumerable<Component> allComponents = await ComponentDP.GetAllComponents();
                Assert.NotNull(allComponents);
                Assert.NotEmpty(allComponents);
                Component foundComponent = allComponents.FirstOrDefault();
                Assert.NotNull(foundComponent);

                CreateOwnsComponentDTO ownsComponentDTO = new CreateOwnsComponentDTO(UserID: foundUser.ID, ComponentID: foundComponent.ID, 20);
                bool wasCreated = await OwnsComponentDP.CreateOwnComponent(ownsComponentDTO);
                Assert.True(wasCreated);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task GetAll()
        {
            try
            {
                IEnumerable<OwnsComponentDTO> allOwnsComponents = await OwnsComponentDP.GetAllOwnsComponents();
                Assert.NotNull(allOwnsComponents);

                foreach(OwnsComponentDTO ownsComponent in allOwnsComponents)
                {
                    Console.WriteLine(ownsComponent.ToString());
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task Update()
        {
            try
            {
                IEnumerable<OwnsComponentDTO> allOwnsComponents = await OwnsComponentDP.GetAllOwnsComponents();
                Assert.NotNull(allOwnsComponents);
                Assert.NotEmpty(allOwnsComponents);
                OwnsComponentDTO ownsComponent = allOwnsComponents.FirstOrDefault();
                Assert.NotNull(ownsComponent);

                int newQuantity = 3000;

                OwnsComponentDTO updateOwnsComponent = new OwnsComponentDTO(ID: ownsComponent.ID, UserID: ownsComponent.UserID, ComponentID: ownsComponent.ComponentID, Quantity: newQuantity);
                bool wasUpdated = await OwnsComponentDP.UpdateOwnsComponent(ownsComponent);
                Assert.True(wasUpdated);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public async Task Delete()
        {
            try
            {
                IEnumerable<OwnsComponentDTO> allOwnsComponents = await OwnsComponentDP.GetAllOwnsComponents();
                Assert.NotNull(allOwnsComponents);
                Assert.NotEmpty(allOwnsComponents);
                OwnsComponentDTO ownsComponent = allOwnsComponents.FirstOrDefault();
                Assert.NotNull(ownsComponent);

                bool wasDeleted = await OwnsComponentDP.DeleteComponent(ownsComponent);
                Assert.True(wasDeleted);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
