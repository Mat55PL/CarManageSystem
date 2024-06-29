import { Component, Injectable, Injector, OnInit } from '@angular/core';
import { finalize, tap } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

class PagedCarsRequestDto extends PagedRequestDto {
  keyword: string;
}

export class CarDto {
  id: number;
  brand: string;
  model: string;
  vin: string;
  year: number;
  fuelType: number;
  wheelType: number;
  numberPlate: string;
}

@Injectable({
  providedIn: 'root'
})
export class CarServiceProxy {
  private baseUrl = 'https://localhost:44359/api/Car';

  constructor(private http: HttpClient) {}

  getAll(keyword: string, skipCount: number, maxResultCount: number): Observable<CarDto[]> {
    const url = `${this.baseUrl}?keyword=${keyword}&skipCount=${skipCount}&maxResultCount=${maxResultCount}`;
    return this.http.get<CarDto[]>(url).pipe(
      tap(data => console.log('Fetched cars:', data)),
      catchError(error => {
        console.error('Error fetching cars', error);
        return of([]);
      })
    );
  }

  delete(id: number): Observable<void> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<void>(url).pipe(
      tap(() => {}),
      catchError(error => {
        console.error('Error deleting car', error);
        return of<void>();
      })
    );
  }
}

@Component({
  templateUrl: './cars.component.html',
  animations: [appModuleAnimation()]
})
export class CarsComponent extends PagedListingComponentBase<CarDto> implements OnInit {
  cars: CarDto[] = [];
  keyword = '';
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _carService: CarServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.getDataPage(1);
  }

  list(
    request: PagedCarsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    console.log('List method called');
    request.keyword = this.keyword;

    this._carService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: CarDto[]) => {
        console.log('Result from service:', result);
        this.cars = result || []; // Ensure this.cars is an empty array if result is undefined
        console.log('Cars after assignment:', this.cars);
        this.showPaging({
            totalCount: this.cars.length,
            items: []
        }, pageNumber);
      });
  }

  delete(car: CarDto): void {
    abp.message.confirm(
      this.l('CarDeleteWarningMessage', car.model),
      undefined,
      (result: boolean) => {
        if (result) {
          this._carService
            .delete(car.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createCar(): void {
    //this.showCreateOrEditCarDialog();
    console.log('Create car');
  }

  editCar(car: CarDto): void {
    //this.showCreateOrEditCarDialog(car.id);
    console.log('Edit car', car);
  }

  clearFilters(): void {
    this.keyword = '';
    this.getDataPage(1);
  }
}
