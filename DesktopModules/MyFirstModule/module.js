$.getJSON(
  "/DesktopModules/MyFirstModule/API/ModuleTask/GetTasks?moduleId=416",
  function (result) {
      var parsedTaskJSONObject = jQuery.parseJSON(result);
      console.log(parsedTaskJSONObject);
      $.each(parsedTaskJSONObject, function () {
          console.log(this.isComplete + this.TaskName + this.TaskDescription);
      });
  });