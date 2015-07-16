<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.MyFirstModule.View" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:DnnJsInclude runat="server" FilePath="~/DesktopModules/MyFirstModule/module.js" />
<div class="AddTaskDiv">
    <h2>Add Task</h2>
    <hr />
    <div class="lblTaskName">Task Name</div>
    <input id="TaskName" type="text" />
     <div class="lblTaskDescription">Task Description</div>
     <input id="TaskDescription" type="text" />
     <div class="isCompleteGroup">
         <input id="cbxIsComplete" type="checkbox" />
         <div class="lblTaskIsComplete">Is Complete</div>
     </div>
     <input class="dnnClear dnnRight dnnPrimaryAction" id="btnAddTask" type="button" value="Add Task" />
</div>
<div class="TaskListDiv">
      <div class="Headings">
            <h2>Complete</h2>
            <h2>Task Name</h2>
            <h2>Task Description</h2>
            <hr/>
      </div>  
     <div class="ListItems">
          <input class="cbxListIsComplete" id="cbxListIsComplete" type="checkbox" />
          <div class="ListTaskName">Task Name PlaceHolder</div>
          <div class="ListTaskDescription">Task Description PlaceHolder</div>
      </div>
</div>