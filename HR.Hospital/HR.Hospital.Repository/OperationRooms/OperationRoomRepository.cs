using System;
using System.Collections.Generic;
using HR.Hospital.Common;
using HR.Hospital.Model;
using System.Linq;
using HR.Hospital.IRepository;
using HR.Hospital.IRepository.OperationRooms;
using HR.Hospital.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace HR.Hospital.Repository.OperationRooms
{
    public class OperationRoomRepository : IOperationRoomRepository
    {
        /// <summary>
        /// 实例化EF上下文对象
        /// </summary>
        private readonly hospitaldbContext _context = new hospitaldbContext();



        /// <summary>
        /// 获取手术间单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperationRoom GetOperationRoom(int id)
        {
            var firstOrDefault = _context.Operationroom.FirstOrDefault(p => p.Id == id);
            return firstOrDefault;
        }

        /// <summary>
        /// 是否开启手术间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EnableOperationRoom(int id)
        {
            var area = _context.Operationroom.FirstOrDefault(p => p.Id == id);
            if (area != null) area.EnableOperation = 3;
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// 查询院区的Id 名字
        /// </summary>
        /// <returns></returns>

        public List<AreaDto> GetListArea()
        {
            var listArea = _context.QueryAreaDto.FromSql("select Id,AreaName from Area where Isnable=0").ToList();
            return listArea;
        }

        /// <summary>
        /// 添加手术间
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        public int AddOperationRoom(OperationRoom operationRoom)
        {
            _context.Operationroom.Add(operationRoom);
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// 修改手术间
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        public int UpdateOperationRoom(OperationRoom operationRoom)
        {
            var firstOrDefault = _context.Operationroom.FirstOrDefault(p => p.Id == operationRoom.Id);
            if (firstOrDefault != null)
            {
                firstOrDefault.OperationName = operationRoom.OperationName;
                firstOrDefault.AreaId = operationRoom.AreaId;
                firstOrDefault.OperationRemark = operationRoom.OperationRemark;
            }
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// 实现分页条件查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="areaId"></param>
        /// <param name="operationName"></param>
        /// <returns></returns>
        public PageHelper<AreaRoomDto> GetListOperationRoom(int pageIndex, int pageSize, int areaId, string operationName)
        {
            var pageAreaRooms = new PageHelper<AreaRoomDto>();

            //执行两表联查
            var areaRoomDtos = _context.QueryAreaRoomDto.FromSql("select a.Id,a.OperationName,a.OperationRemark,a.AreaId,b.AreaName from operationroom  a join area b on b.Id=a.AreaId where a.EnableOperation=0 and b.Isnable=0").ToList();
            //总条数
            var total = areaRoomDtos.Count();
            //赋值给这个类的总条数
            pageAreaRooms.PageSizes = total;
            //总页数赋值
            pageAreaRooms.PageNum = (total / pageSize);
            //给集合赋值
            pageAreaRooms.PageList = areaRoomDtos;

            if (areaId != 3)
            {
                //执行两表联查
                areaRoomDtos = areaRoomDtos.OrderBy(p => p.Id).Where(p => p.AreaId == areaId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                //总条数
                total = areaRoomDtos.Count(p => p.AreaId == areaId);
                //赋值给这个类的总条数
                pageAreaRooms.PageSizes = total;
                //总页数赋值
                pageAreaRooms.PageNum = (total / pageSize);
                //给集合赋值
                pageAreaRooms.PageList = areaRoomDtos;
            }
            if (areaId != 3 && operationName != null)
            {
                areaRoomDtos = areaRoomDtos.OrderBy(p => p.Id).Where(p => p.AreaId == areaId && p.OperationName.Contains(operationName)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = areaRoomDtos.Count(p => p.AreaId == areaId && p.OperationName.Contains(operationName));
                //赋值给这个类的总条数
                pageAreaRooms.PageSizes = total;
                //总页数赋值
                pageAreaRooms.PageNum = (total / pageSize);
                //给集合赋值
                pageAreaRooms.PageList = areaRoomDtos;
            }
            if (operationName == null) return pageAreaRooms;
            {
                areaRoomDtos = areaRoomDtos.OrderBy(p => p.Id).Where(p => p.OperationName.Contains(operationName)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = areaRoomDtos.Count(p => p.OperationName.Contains(operationName));
                //赋值给这个类的总条数
                pageAreaRooms.PageSizes = total;
                //总页数赋值
                pageAreaRooms.PageNum = (total / pageSize);
                //给集合赋值
                pageAreaRooms.PageList = areaRoomDtos;
            }
            return pageAreaRooms;
        }


    }
}
