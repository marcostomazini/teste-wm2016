
// To run this code, edit file index.html or index.jade and change
// html data-ng-app attribute from angle to myAppName
// ----------------------------------------------------------------------

(function() {
    'use strict';
    angular.module('app.agenda').controller('AgendaController', [
	'$scope',
	'$interval',
	'$stateParams',
	'$location',
	'DTOptionsBuilder',
	'DTColumnDefBuilder',
	'SweetAlert',
    '$uibModal',
    '$http',
	function ($scope,
		$interval,
		$stateParams,
		$location,
		DTOptionsBuilder,
		DTColumnDefBuilder,
		SweetAlert,
        $uibModal,
        $http) {

	    this.dtOptions = DTOptionsBuilder
            .newOptions()
            .withOption('bLengthChange', false)
            .withOption('bInfo', false)
            .withOption('processing', true)
            .withPaginationType('full_numbers');

	    this.dtColumnDefs = [
			DTColumnDefBuilder
				.newColumnDef(0)
				.withOption('bSearchable', false)
				.notVisible()
				.notSortable(),
	        DTColumnDefBuilder
	        	.newColumnDef(1)
	        	.notSortable()
	    ];

	    $scope.urlBase = '/#!/usuarios-mobile';	  

	    $http({
	        method: 'GET',
	        url: '/Agenda/BuscaAgenda'
	    }).then(function successCallback(response) {
	        $scope.agendas = response.data;
	    }, function errorCallback(response) {

	    });
	    

	    ModalInstanceCtrl.$inject = ['$scope', '$uibModal', 'DTOptionsBuilder', 'DTColumnDefBuilder', 'item'];
	    function ModalInstanceCtrl($scope, $uibModal, DTOptionsBuilder, DTColumnDefBuilder, item) {

	        $scope.dtOptionsTelefone = DTOptionsBuilder
               .newOptions()
               .withOption('bLengthChange', false)
               .withOption('bInfo', false)
                .withOption('bFilter', false)
               .withOption('processing', true)
               .withPaginationType('full_numbers');

	        $scope.dtColumnDefsTelefone = [
                DTColumnDefBuilder
                    .newColumnDef(0)
                    .withOption('bSearchable', false)
                    .notVisible()
                    .notSortable(),
                DTColumnDefBuilder
                    .newColumnDef(1)
                    .notSortable()
	        ];

	        $http({
	            method: 'GET',
	            url: '/Agenda/BuscaTiposTelefone'
	        }).then(function successCallback(response) {
	            $scope.tiposTelefone = response;
	        }, function errorCallback(response) {

	        });

	        if (item == undefined) {
	            $scope.telefones = {
	                telefones: []
	            };
	        } else {
	            $http({
	                method: 'GET',
	                url: '/Agenda/BuscaTelefonesPorId/' + item.cdAgenda
	            }).then(function successCallback(response) {
	                $scope.telefones = response.data;
	            }, function errorCallback(response) {

	            });
	        }	        

	        $scope.open = function ($event) {
	            $event.preventDefault();
	            $event.stopPropagation();

	            $scope.opened = true;
	        };

	        $scope.ok = function (objeto) {

	            if (objeto == undefined || objeto.nome == undefined || objeto.nome == '') {
	                SweetAlert.swal('Erro!', 'existem campos não preenchidos', 'error');
	                return;
	            }
	            var model = objeto;

	            if ($scope.showInputs) {
	                $scope.showInputs = false;
	                $scope.telefones.telefones.push(objeto);
	                $scope.telefone = {};
	            } else {
	                $http({
	                    method: 'POST',
	                    url: '/Agenda/SalvarAgenda',
	                    data: $scope.telefones
	                }).then(function successCallback(response) {
	                    $scope.$close();
	                }, function errorCallback(response) {

	                });
	            }
	        };

	        $scope.cancel = function () {

	            if ($scope.showInputs) {
	                $scope.showInputs = false;
	            } else
	                $scope.$dismiss();
	        };


	        $scope.addItem = function (item) {
	            $scope.showInputs = true;
	        };
	    }

	    $scope.addItem = function (item) {
	        var modalInstance = $uibModal.open({
	            templateUrl: 'modalInserir.html',
	            controller: ModalInstanceCtrl,
	            resolve: {
	                item: item
	            },
	            size: 'md'
	        });

	        var state = $('#modal-state');
	        modalInstance.result.then(function () {
	            $http({
	                method: 'GET',
	                url: '/Agenda/BuscaAgenda'
	            }).then(function successCallback(response) {
	                $scope.agendas = response.data;
	            }, function errorCallback(response) {

	            });
	        }, function () {
	            state.text('Modal dismissed with Cancel status');
	        });
	    };

	    $scope.visualizar = function (item) {
	        $scope.addItem(item);
	    };

	    $scope.deleteConfirm = function (index) {
	        SweetAlert.swal({
	            title: 'Você tem certeza?',
	            text: 'Após deletado não vai ser mais possível acessar o registro!',
	            type: 'warning',
	            showCancelButton: true,
	            confirmButtonColor: '#DD6B55',
	            confirmButtonText: 'Sim',
	            cancelButtonText: 'Não',
	            closeOnConfirm: false,
	            closeOnCancel: false
	        }, function (isConfirm) {
	            if (isConfirm) {
	                var usuarioMobile = $scope.leiloes[index];
	                if (usuarioMobile) {
	                    usuarioMobile.$remove(function (response) {
	                        if (response) {
	                            $scope.leiloes = _.without($scope.leiloes, usuarioMobile);

	                            SweetAlert.swal('Deletado!', 'O registro foi deletado.', 'success');
	                        }
	                    }, function (errorResponse) {
	                        $scope.error = errorResponse.data.message;
	                        SweetAlert.swal('Erro!', errorResponse.data.message, errorResponse.data.type);
	                    });
	                }

	            } else {
	                SweetAlert.swal('Cancelado', 'O registro não foi removido :)', 'error');
	            }
	        });
	    };
	}
    ]);
})();
