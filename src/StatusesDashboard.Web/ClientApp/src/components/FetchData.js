import React, { Component } from "react";

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { companies: [], loading: true };
  }

  componentDidMount() {
    try {
      setInterval(async () => {
        await this.populateCompaniesData()      
      }, 5000);
    } catch(e) {
      console.log(e);
    }    
  }

  static renderCompaniesTable(companies) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Company</th>
            <th>Address</th>
            <th>Cars</th>
          </tr>
        </thead>
        <tbody>
          {companies.map((company) => (
            <tr key={company.id}>
              <td>{company.name}</td>
              <td>{company.address}</td>
              <td>
                {company.cars.map((car) => (
                  <p>
                    {car.vinCode}, {car.registrationNumber}, {car.status}
                  </p>
                ))}
              </td>
              <td>{company.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      FetchData.renderCompaniesTable(this.state.companies)
    );

    return (
      <div>
        <h1 id="tabelLabel">Companies with vehicles</h1>
        <br />
        {this.renderCompaniesFilter(this.state.companies)}
        <br />
        {this.renderStatusFilter()}
        {contents}
      </div>
    );
  }

  renderCompaniesFilter(companies) {
    return companies.map((company) => (
      <a href="#" onClick={() => this.populateCompanyData(company.id)}>
       {company.name}&nbsp;&nbsp;&nbsp;
      </a>
    ));
  }

  renderStatusFilter() {
    return (
      <div>
        <a
          href="#"
          onClick={() => this.populateCompaniesData()}
        >
          All&nbsp;&nbsp;&nbsp;
        </a>
        <a
          href="#"
          onClick={() => this.populateCompaniesDataByCarStatus(0)}
        >
          Online&nbsp;&nbsp;&nbsp;
        </a>
        <a
          href="#"
          onClick={() => this.populateCompaniesDataByCarStatus(1)}
        >
          Offline&nbsp;
        </a>
      </div>
    );
  }

  async populateCompaniesData() {
    const response = await fetch("api/company");
    const data = await response.json();
    this.setState({ companies: data, loading: false });
  }

  async populateCompanyData(companyId) {
    const response = await fetch(`api/company/${companyId}`);
    const data = await response.json();
    this.setState({ companies: [data], loading: false });
  }

  async populateCompaniesDataByCarStatus(status) {
    const response = await fetch(`api/company/car/status/${status}`);
    const data = await response.json();
    this.setState({ companies: data, loading: false });
  }
}
