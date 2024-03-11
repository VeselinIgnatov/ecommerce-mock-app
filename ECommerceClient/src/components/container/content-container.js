import React, { Fragment } from 'react'
import { Search } from '../search/search'
import { CardList } from '../card-list/card-list'

export const Container = () => {
    return (<Fragment>
        <Search />
        <CardList />
    </Fragment>)
}