﻿using System;
using System.Collections.Generic;
using System.Linq;
using HR.Hospital.IRepository.ApprovalFunction;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.ApprovalFunction
{
    public class ApprovalConfigurationRepository : IApprovalConfigurationRepository
    {

        private readonly hospitaldbContext _context = new hospitaldbContext();

        /// <summary>
        /// 添加配置表信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        public int AddApprovalConfiguration(List<ApprovalConfiguration> approvalConfiguration)
        {
            var result = 0;
            var oneId = 0;
            var twoId = 0;
            using (var tr = _context.Database.BeginTransaction())
            {

                try
                {      //进行循环这个集合
                    foreach (var configuration in approvalConfiguration)
                    {
                        //进行一个添加操作
                        _context.ApprovalConfiguration.Add(configuration);
                        //进入保存一个操作
                        _context.SaveChanges();
                        //先进行把TwoId赋值给OneId
                        oneId = twoId;
                        //再把twoId赋值为当前的Id
                        twoId = configuration.Id;
                        //去配置表中查询是否有这个活动而且下一步Id为0的数据
                        var queryable = _context.ApprovalConfiguration.FirstOrDefault(p => p.Id == oneId);
                        if (queryable == null) continue;
                        queryable.DownId = twoId;
                        //如果为空那么返回自增长Id
                        result = _context.SaveChanges();
                        //不为空则修改为当前自增长Id
                        
                    }
                   
                    tr.Commit();
                    return 1;
                }
                catch (Exception e)
                {
                    tr.Rollback();
                    Console.WriteLine(e);
                    return result;
                }
                finally
                {
                    _context.Dispose();
                  
                }

            }

           
            //var result = _context.SaveChanges();
            //return result;
        }

        /// <summary>
        /// 显示分页配置表信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        public List<ApprovalConfiguration> GetApprovalConfigurations(int pageIndex, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改配置表信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        public int UpdateApprovalConfiguration(ApprovalConfiguration approvalConfiguration)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 单独查询活动Id
        /// </summary>
        /// <returns></returns>
        public List<int> GetActivityId()
        {
            var activityIdList = _context.ApprovalConfiguration.Select(p => p.ActivityId).ToList();
            return activityIdList;
        }
    }
}