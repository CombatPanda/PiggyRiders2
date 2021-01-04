import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import Logo from '../piggy.svg';

export class NavMenu extends Component {
  
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
        <div>
            <ul id="dropdown" className="dropdown-content">
                <li><a href="/sign-up">Sign Up</a></li>
                <li className="divider"></li>
                <li><a href="/BMInfo">Budget Manager</a></li>
                <li className="divider"></li>
                <li><a href="/SavingsManagerInformations">Saving Manager</a></li>
                <li className="divider"></li>
                <li><a href="/ExpensesManagerInformations">Expenses Manager</a></li>
                <li><a href="/ExpensesManagerInformations/add">Add Limit</a></li>
                <li className="divider"></li>
                <li><a href="/Challenges">Challenges</a></li>
                <li><a href="/Leaderboard">Leader board</a></li>
            </ul>
            <img class="logo" src={Logo}/>
                <div className="nav-wrapper">
                    <ul className="right hide-on-med-and-down">
                        <li><a className="dropdown-trigger" href="#!" data-target="dropdown">Menu</a></li>
                    </ul>
                 </div>
        </div>
    );
  }
}
