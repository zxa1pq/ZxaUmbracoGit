angular.module("umbraco.resource")
.factory("personResource", function ($http) {

    return {
        getById: function (id) {

            return $http.get("backoffice/Example/PersonApi/GetById?id=" + id);
        },
        save: function (person) {
            return $http.post("backoffice/Exampl/PersonApi/PostSave", angular.toJson(person));
        },
        deleteById: function (id) {
            return $http.delete("backoffice/Example/PersonApi/DeleteById?id" + id);
        }
    };
});